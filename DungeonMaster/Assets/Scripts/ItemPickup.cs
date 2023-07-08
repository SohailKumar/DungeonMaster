using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemPickup : MonoBehaviour
{
    public Items item;

    void Pickup()
    {
        var ItemId = gameObject.GetComponent<ItemController>().Item;
        Debug.Log(ItemId);
        InventoryManager.Instance.Add(item);
        InventoryManager.Instance.ListItems();

        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        Pickup();
    }

}
