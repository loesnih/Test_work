using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combat : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject thisWeapon;
    public float attackRange = 0.5f;
    public LayerMask grassLayers;
    public LayerMask enemyLayers;

    public UnityEvent effects;

    public int attackDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Attack()
    {
        Collider2D[] hitGrass = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, grassLayers);
        
        foreach (Collider2D grass in hitGrass)
        {
            Debug.Log("Партия! Удар!");
            
            grass.GetComponent<Seno>().TakeDamage(attackDamage);
        }
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemys in hitEnemys)
        {
            Debug.Log("Минус чашка рис!");

            enemys.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

    public void fx()
    {
        effects.Invoke();
    }

    public void Deactivate()
    {
        thisWeapon.SetActive(false);
    }
}
