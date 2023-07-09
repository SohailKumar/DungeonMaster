using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryManager : GenericSingleton<InventoryManager>
{
    public List<Items> items = new List<Items>();
    public List<Trap> traps = new List<Trap>();
    public List<GameObject> droppedItems = new List<GameObject>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject ItemToInstantiate;

    public Items[] levelOnePrefabs;
    public Items[] levelTwoPrefabs;

    public void Start()
    {
        GenerateRandomItem(new Vector2(-3.85f, -3.6f), 1);
        GenerateRandomItem(new Vector2(-3.85f+1f, -3.6f), 1);
        GenerateRandomItem(new Vector2(-3.85f-1f, -3.6f), 1);
    }

    public void AddItem(Items item)
    {
        items.Add(item);
    }
    
    public void RemoveItem(Items item)
    {
        items.Remove(item);
    }

    public void AddTrap(Trap trap)
    {
        traps.Add(trap);
    }

    public void RemoveTrap(Trap trap)
    {
        traps.Remove(trap);
    }

    public GameObject GenerateRandomItem(Vector2 position, int tier)
    {
        GameObject obj = Instantiate(ItemToInstantiate);
        obj.transform.position = position;
        if(tier == 1)
        {
            int rand = Random.Range(0,levelOnePrefabs.Length);
            obj.GetComponent<SpriteRenderer>().sprite = levelOnePrefabs[rand].image;
            obj.GetComponent<ItemController>().Item = levelOnePrefabs[rand];
            obj.GetComponent<ItemPickup>().item = levelOnePrefabs[rand];
        }
        else
        {
            int rand = Random.Range(0, levelTwoPrefabs.Length);
            obj.GetComponent<SpriteRenderer>().sprite = levelTwoPrefabs[rand].image;
            obj.GetComponent<ItemController>().Item = levelTwoPrefabs[rand];
            obj.GetComponent<ItemPickup>().item = levelTwoPrefabs[rand];
        }
        
        return obj;
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

            var Popup = obj.transform.Find("InfoPopup").GetChild(0);

            var CardName = Popup.transform.Find("ItemNameCard").GetComponent<TMP_Text>();
            var CardValue = Popup.transform.Find("Value").GetComponent<TMP_Text>();
            var CardImage = Popup.transform.Find("CardImage").GetComponent<Image>();
            var CardFlavor = Popup.transform.Find("FlavorText").GetComponent<TMP_Text>();
            var CardAtkDef = Popup.transform.Find("AtkDefText").GetComponent<TMP_Text>();

            itemID.Item = item;
            itemName.text = item.itemName;
            itemIcon.sprite = item.image;

            CardName.text = item.itemName;
            CardValue.text = item.saleAmount + " Coins";
            CardImage.sprite = item.image;
            CardFlavor.text = item.flavortext;
            CardAtkDef.text = item.AttackDamage + " Attack Damage\n" + item.Defense + " Defense";
        }

        foreach (var trap in traps)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var trapName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var trapIcon = obj.transform.Find("Image").GetComponent<Image>();
            var trapID = obj.transform.GetComponent<ItemController>();

            trapID.Trap = trap;
            trapID.isTrap = true;
            trapName.text = trap.trapname;
            trapIcon.sprite = trap.image;
        }
    }

    public void InventorySizeForScene(Vector2 position, Vector2 SpaceOccupied)
    {
        ItemContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, SpaceOccupied.y);
        ItemContent.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(SpaceOccupied.x, SpaceOccupied.y);
        ItemContent.parent.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(SpaceOccupied.x, SpaceOccupied.y);
    }
}
