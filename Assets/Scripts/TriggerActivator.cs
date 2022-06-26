using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActivator : MonoBehaviour
{
    public UnityEvent this_event;
    public GameObject this_gameObject;  
    [SerializeField] string activatorTag = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(activatorTag))
        {
            StartCoroutine(DieMoment());
        }
    }
    IEnumerator DieMoment()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this_gameObject);
    }
}
