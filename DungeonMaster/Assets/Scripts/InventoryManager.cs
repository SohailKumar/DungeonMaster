using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryManager : GenericSingleton<InventoryManager>
{
    public List<Items> items = new List<Items>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public void Add(Items item)
    {
        items.Add(item);
    }
    
    public void Remove(Items item)
    {
        items.Remove(item);
    }


    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {

            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
            var itemID = obj.transform.GetComponent<ItemController>();

            Debug.Log(itemID);
            Debug.Log(itemName);
            Debug.Log(itemIcon);
            itemID.Item = item;
            itemName.text = item.itemName;
            itemIcon.sprite = item.image;
        }
    }
}
