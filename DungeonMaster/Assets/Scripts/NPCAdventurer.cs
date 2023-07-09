using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAdventurer : MonoBehaviour
{
    public int tier;

    public float speed = 0.05f;
    public float Maxhealth = 20;
    float health;
    public float knockbackMax = 1f;
    
    public float knockbackForce = 0.05f;
    private bool knockedBack = false;
    private float knockbackTimer = 0f;

    private void Start()
    {
        health = Maxhealth;
    }

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
        float damageOffset = (health / Maxhealth);
        gameObject.transform.GetChild(1).transform.localScale = new Vector2(damageOffset, 0.1f);
        gameObject.transform.GetChild(1).transform.position = new Vector2(gameObject.transform.GetChild(1).transform.position.x-(.35f-.35f*damageOffset), gameObject.transform.GetChild(1).transform.position.y);
    }

    private void TakeKnockback()
    {
        knockedBack = true;
    }

    public void Die()
    {
        GameManager.ReduceEnemies();
        InventoryManager.Instance.droppedItems.Add(InventoryManager.Instance.GenerateRandomItem(new Vector2(transform.position.x,transform.position.y+0.5f), tier));
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
            TakeDamage(dmg);
            TakeKnockback();
        }
    }
}
