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
        InventoryManager.Instance.AddItem(item);
        InventoryManager.Instance.ListItems();

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }

}
