using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public float speed;
    public ParticleSystem FX;
    private Transform endpoint;
    public bool rotation;

    public int maxHealth = 10;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        endpoint = GameObject.FindGameObjectWithTag("EndPoint").GetComponent<Transform>();
        gameObject.GetComponentInParent<Transform>().rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endpoint.position, speed * Time.deltaTime);
        if (rotation)
        {
            anim.SetBool("down",true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemys")
        {
            PlayFX();
        }
    }
    public void TakeDamage(int damage)
    {
       currentHealth -= damage;
        if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
    }

    public void PlayFX()
    {
        speed = 0;
        FX.Play();
        StartCoroutine(DieMoment());
    }

    IEnumerator DieMoment()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
