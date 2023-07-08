using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items item;

    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        Pickup();

        
    }

}
