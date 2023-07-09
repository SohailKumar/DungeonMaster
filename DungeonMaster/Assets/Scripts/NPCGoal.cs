using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("THINGERMEBAB: " + collision.gameObject.name);
        if (collision.CompareTag("Adventurer"))
        {
            collision.GetComponent<NPCAdventurer>().Die();
        } 
    }
}
