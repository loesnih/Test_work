using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float moveInput;
    public float moveInput_2;
    Animator anim;

    public bool May_Use_Weapon = true;

    private Vector2 MoveVelocity;


    public Joystick joystick;

    public int count;
    public int MaxCount;

    public int Cash;

    [SerializeField] GameObject Weapon;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        MoveVelocity = moveInput.normalized * speed;
        Flip();

        if (count >= MaxCount)
        {
            count = MaxCount;
            Dectivate();
            Weapon.SetActive(false);
        }
        if (count < MaxCount)
        {
            Activate();
        }
        if(count <= 0)
        {
            count = 0;
        }


    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveVelocity * Time.deltaTime);
    }

    public void Flip()
    {
        if (joystick.Horizontal > 0)
            {
            anim.SetBool("Run_LR", true);
                transform.localRotation = Quaternion.Euler(23, 0, 0);
            }
        if (joystick.Horizontal < 0)
        {
            anim.SetBool("Run_LR", true);
            
            transform.localRotation = Quaternion.Euler(23, 180, 0);
        }
        if(joystick.Horizontal == 0)
        {
            anim.SetBool("Run_LR", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "Seno")
            {
                print("Çהוסü");
                Weapon.SetActive(true);
        }
        else if (collision.gameObject.tag == "Enemys")
        {
            Weapon.SetActive(true);
        }
    }

    public void Activate()
    {
        May_Use_Weapon = true;
    }
    public void Dectivate()
    {
        May_Use_Weapon = false;
    }
}
