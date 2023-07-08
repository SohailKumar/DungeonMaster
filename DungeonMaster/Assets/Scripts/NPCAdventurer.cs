using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAdventurer : MonoBehaviour
{
    public float speed = 0.05f;
    public float health = 20;

    private bool stopMoving = false;

    // Update is called once per frame
    void Update()
    {
        if(!stopMoving)
            transform.position = new Vector2(transform.position.x+speed, transform.position.y);


        if(health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

    }

    private void TakeKnockback()
    {
        stopMoving = true;
    }

    public void Die()
    {

    }
}
