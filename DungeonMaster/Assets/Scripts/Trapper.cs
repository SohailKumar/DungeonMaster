using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapper : MonoBehaviour
{
    [SerializeField] public float attackSpeed;
    [SerializeField] public int damage;
    [SerializeField] public GameObject particleEffect;
    public TrapPlacementSlot upgradeDmg;

    private void Start()
    {
        InvokeRepeating("DPS", 0.0f, attackSpeed);
    }
    void DPS()
    {
        GameObject.Instantiate(particleEffect, transform.position + Vector3.up*0.4f, Quaternion.Euler(-90, 0, 0));
        List<Collider2D> hitColliders = new List<Collider2D>();
        ContactFilter2D _contactFilter = new ContactFilter2D();
        Physics2D.OverlapCollider(transform.GetComponent<Collider2D>(), _contactFilter, hitColliders);

        foreach(Collider2D col in hitColliders)
        {
            if (col.tag == "Adventurer")
            {
                Debug.Log(damage);
                Debug.Log(upgradeDmg.additionalAttack);
                col.GetComponent<NPCAdventurer>().TakeTrapDamage(damage + upgradeDmg.additionalAttack);
            }

        }
    }
}
