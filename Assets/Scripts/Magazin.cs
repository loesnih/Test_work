using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magazin : MonoBehaviour
{
    public UnityEvent events;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Untagged")
        {
            events.Invoke();
        }
        if (collision.gameObject.tag == "Player")
        {
            events.Invoke();
        }

    }
}
