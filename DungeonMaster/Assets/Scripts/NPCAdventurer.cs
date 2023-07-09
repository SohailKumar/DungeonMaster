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
    public float damageMax = 0.6f;
    
    public float knockbackForce = 0.05f;
    private bool knockedBack = false;
    private float knockbackTimer = 0f;

    public float mouseAttackMax = 0.6f;
    private float mouseAttackTimer;
    

    [SerializeField] private float damageTimer = 0f;
    private bool damaged = false;


    private void Start()
    {
        health = Maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponentsInChildren<SpriteRenderer>()[3].color = Color.red;
        if (!knockedBack)
            transform.position = new Vector2(transform.position.x+speed, transform.position.y);
        else
        {
            knockbackTimer += Time.deltaTime;
            transform.position = new Vector2(transform.position.x - knockbackForce*2*(knockbackMax-knockbackTimer), transform.position.y);

            if(knockbackTimer > knockbackMax)
            {
                knockedBack = false;
                knockbackTimer = 0;
            }
        }

        if (damageTimer > 0 && damaged)
        {
            damageTimer -= Time.deltaTime;
            GetComponentsInChildren<SpriteRenderer>()[3].color = Color.red;
            if (damageTimer <= 0)
            {
                GetComponentsInChildren<SpriteRenderer>()[3].color = Color.white;
                damaged = false;
            }
        }

        if (mouseAttackTimer > 0)
        {
            mouseAttackTimer -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!damaged)
        {
            damaged = true;
            damageTimer = damageMax;
            health -= damage;
            if (health < 0){
                health = 0;
            }
            float damageOffset = (health / Maxhealth);
            gameObject.transform.GetChild(1).transform.localScale = new Vector2(damageOffset, 0.1f);
            //gameObject.transform.GetChild(1).transform.position = new Vector2(gameObject.transform.GetChild(1).transform.position.x-(.35f-.35f*damageOffset), gameObject.transform.GetChild(1).transform.position.y);
        }
        
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
    /*
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
    */
    private void OnMouseDown()
    {
        if(mouseAttackTimer <= 0)
        {
            mouseAttackTimer = mouseAttackMax;
            TakeDamage(10);
            if(!knockedBack)
            {
                TakeKnockback();
            }
        }
        
    }

    public void TakeTrapDamage(int dmg, bool knockback)
    {
        TakeDamage(dmg);

        if (knockback && !knockedBack)
        {    
            TakeKnockback();
        }
    }
}
