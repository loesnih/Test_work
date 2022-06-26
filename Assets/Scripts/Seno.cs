
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seno : MonoBehaviour
{
    Animator anim;
    [SerializeField] ParticleSystem FX_Enter;
    [SerializeField] GameObject[] pochatok;
    [SerializeField] ParticleSystem Fx;

    public bool MayHit = true;


    public float respawnTime;
    public int maxHealth = 10;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (MayHit == true)
        {
            currentHealth -= damage;
            Fx.Play();

            if (currentHealth <= 0)
            {
                MayHit = false;
                anim.SetBool("Ready", false);
                gameObject.tag = "Untagged";
                Surprise();
                StartCoroutine(Respawn_1());
            }
        }
        
    }

    void Surprise()
    {
        GameObject obj = Instantiate(pochatok[Random.Range(0, pochatok.Length)], this.transform) as GameObject;
        obj.transform.localPosition = new Vector3(Random.Range(-1f,1f),0f,0);
    }

    IEnumerator Respawn_1()
    {
        Debug.Log("Die");
        yield return new WaitForSeconds(respawnTime);
        anim.SetBool("Ready", true);
        currentHealth = maxHealth;
        MayHit = true;
        gameObject.tag = "Seno";
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
            if (MayHit == true)
            {
                FX_Enter.Play();
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }
}
