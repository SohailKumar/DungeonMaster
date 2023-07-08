using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;
    public List<Items> items = new List<Items>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

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
        foreach(var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.image;
        }
    }
}
