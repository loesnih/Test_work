using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Manager manager;
    private Player player;
    public GameObject slotButton;
    Rigidbody2D rb;
    public float speed;
    public float time_to_die;
    public bool mayPick = true;

    public bool Go;

    public bool Cash;

    private Transform target;
    private Transform magazin;
    //public Transform point;

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Transformer").GetComponent<Transform>();
        magazin = GameObject.FindGameObjectWithTag("Ambar").GetComponent<Transform>();
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        StartCoroutine(DieTime());
    }

    private void FixedUpdate()
    {
        if (Go)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed /2 * Time.deltaTime);
        }

        if (Cash)
        {
            Go = false;
            transform.position = Vector2.MoveTowards(transform.position, magazin.position, speed / 2 * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.May_Use_Weapon == true)
            {
                Get_this();
            }

        }
        if (collision.gameObject.tag == "Ambar")
        {
            GetCash();
        }
    }


    public void Get_this()
    {
        player.count++;
        mayPick = false;
        StopAllCoroutines();
        Upper();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        manager.LetsGo();
        Destroy(gameObject);
    }

    public void Upper()
    {
        Go = true;
        rb.gravityScale = 0f;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        gameObject.layer = LayerMask.NameToLayer("Spirit");
        
    }

    public void GetCash()
    {
        Cash = true;
        rb.gravityScale = 0f;
        player.count--;
        StartCoroutine(Delay());
    }

    IEnumerator DieTime()
    {
        if (mayPick == true)
        {
            yield return new WaitForSeconds(time_to_die);
            Destroy(gameObject);
        }
    }
}
