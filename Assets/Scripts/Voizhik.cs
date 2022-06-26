using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voizhik : MonoBehaviour
{
    [SerializeField] float speed;
    public float StoppingDistance;

    [SerializeField] Transform ambar_pos;
    public bool razgruz;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (razgruz)
        {
            transform.position = Vector2.MoveTowards(transform.position, ambar_pos.position, speed * Time.deltaTime);
            if (transform.position == ambar_pos.position)
            {
                razgruz = false;
            }
        }
        
        if (!razgruz)
        {
            if (Vector2.Distance(transform.position, target.position) > StoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    public void Stopper()
    {
        razgruz = true;
        StartCoroutine(Disablebool());
    }

    IEnumerator Disablebool()
    {
        yield return new WaitForSeconds(3f);
        razgruz = false;
    }

    public void RazgruzStop()
    {
        razgruz = false;
    }
}
