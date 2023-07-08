using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTrap : MonoBehaviour
{
    GameManager gm;
    [SerializeField] GameObject trapSelectButton;

    private void OnEnable()
    {
        //gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if(GameManager.trapInventory != null)
        {
            foreach(GameObject j in GameManager.trapInventory)
            {
                Instantiate(trapSelectButton, transform.position, Quaternion.identity, transform);
            }
        }
        
    }

    private void OnDisable()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
