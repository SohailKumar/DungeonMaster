using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAdventurer : MonoBehaviour
{
    public float speed = 0.05f;
    public float health = 20;
    public float knockbackMax = 1f;

    public float knockbackForce = 0.05f;
    private bool knockedBack = false;
    private float knockbackTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if(!knockedBack)
            transform.position = new Vector2(transform.position.x+speed, transform.position.y);
        else
        {
            knockbackTimer += Time.deltaTime;
            transform.position = new Vector2(transform.position.x - knockbackForce*2*(knockbackMax-knockbackTimer), transform.position.y);

            if(knockbackTimer > knockbackMax)
            {
                knockedBack = false;
                knockbackTimer = 0;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }


        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        health -= damage;

    }

    private void TakeKnockback()
    {
        knockedBack = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        if(!knockedBack)
            GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void OnMouseExit()
    {
        if(!knockedBack)
            GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        if(!knockedBack)
        {
            TakeDamage(5);
            TakeKnockback();
        }
    }

    public void TakeTrapDamage(int dmg)
    {
        if (!knockedBack)
        {
            Debug.Log("DMADL:KFJSDIUEIFJ");
            TakeDamage(dmg);
            TakeKnockback();
        }
        
    }
}
