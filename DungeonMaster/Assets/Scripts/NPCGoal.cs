using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCGoal : MonoBehaviour
{
    [SerializeField] public List<GameObject> defenses = new List<GameObject>();
    public int addDefense = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("THINGERMEBAB: " + collision.gameObject.name);
        if (collision.CompareTag("Adventurer"))
        {
            collision.GetComponent<NPCAdventurer>().Die();

            if (addDefense >= 20)
            {
                addDefense -= 20;
            }
            else if (addDefense - 20 < 0)
            {
                CurrencySystem.Instance.loseMoney(20 - addDefense);
                addDefense = 0;
            }
            
            Debug.Log("Money: " + CurrencySystem.Instance.getMoney());
        }
    }

    public void OnStart()
    {
        Debug.Log("thing");
        foreach (GameObject obj in defenses)
        {
            if (obj.transform.childCount > 0)
            {
                addDefense += obj.GetComponentInChildren<ItemController>().Item.Defense;
            }
        }
    }

    private void Update()
    {
        if (CurrencySystem.Instance.getMoney() <= 0)
        {
            // Player Loses
            SceneManager.LoadScene("MainMenu");
        }
    }
}
