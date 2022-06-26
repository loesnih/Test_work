using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turel : MonoBehaviour
{
    public Transform this_Pos;
    public float speed;
    public bool Go;
    public ParticleSystem FX_Air;
    public ParticleSystem FX_Dym;
    public GameObject weapon;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, this_Pos.position, speed * Time.deltaTime);
        if (Go)
        {
            if (transform.position == this_Pos.position)
            {

                speed = 0;
                FxOff();
                Go = false;
            }
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemys")
        {
            weapon.SetActive(true);
        }
    }

    public void FxOff()
    {
        FX_Air.Stop();
        FX_Dym.Play();
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }
}
