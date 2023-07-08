using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapper : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private int damage;

    private void Start()
    {
        InvokeRepeating("DPS", 0.0f, attackSpeed);
    }
    void DPS()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.localScale, 0);

        foreach(Collider2D col in hitColliders)
        {
            col.GetComponent<NPCAdventurer>().TakeTrapDamage(damage);
        }
    }
}
