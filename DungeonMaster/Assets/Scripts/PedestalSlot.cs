using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PedestalSlot : MonoBehaviour, IDropHandler

{
    public AudioSource source;
    public AudioClip clip;

    public enum DropAcceptType
    {
        Item,
        Trap,
        All
    }

    public DropAcceptType dropAcceptType = DropAcceptType.Item;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped.GetComponent<ItemController>() == null)
        {
            return;
        }

        if (dropped.GetComponent<ItemController>().isTrap && dropAcceptType == DropAcceptType.Trap
            || !dropped.GetComponent<ItemController>().isTrap && dropAcceptType == DropAcceptType.Item
            || dropAcceptType == DropAcceptType.All)
        {
            source = GameObject.Find("Canvas/InventoryManager").GetComponent<AudioSource>();
            Debug.Log(source);
            source.PlayOneShot(clip);
            if (transform.childCount == 0)
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                if (draggableItem != null)
                {
                    source = GameObject.Find("Canvas/InventoryManager").GetComponent<AudioSource>();
                    source.PlayOneShot(clip);
                    draggableItem.parentAfterDrag = transform;
                    draggableItem.GetComponent<Image>().color = new Color(draggableItem.GetComponent<Image>().color.r, draggableItem.GetComponent<Image>().color.g, draggableItem.GetComponent<Image>().color.b, 0);
                    draggableItem.GetComponentInChildren<TextMeshProUGUI>().color = 
                        new Color(draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.r,
                        draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.g,
                        draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.b, 0);
                }

                // Remove it from inventory
                if (dropped.GetComponent<ItemController>().isTrap && !dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.RemoveTrap(dropped.GetComponent<ItemController>().Trap);
                    dropped.GetComponent<DraggableItem>().isRemoved = true;
                }
                else if (!dropped.GetComponent<ItemController>().isTrap && !dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.RemoveItem(dropped.GetComponent<ItemController>().Item);
                    dropped.GetComponent<DraggableItem>().isRemoved = true;
                }
            }
            else if (transform.name == "Content")
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                if (draggableItem != null)
                {
                    source.PlayOneShot(clip);
                    draggableItem.parentAfterDrag = transform;
                    draggableItem.GetComponent<Image>().color = new Color(draggableItem.GetComponent<Image>().color.r, draggableItem.GetComponent<Image>().color.g, draggableItem.GetComponent<Image>().color.b, 255);
                    draggableItem.GetComponentInChildren<TextMeshProUGUI>().color = 
                        new Color(draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.r,
                        draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.g,
                        draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.b, 225);
                }

                if (dropped.GetComponent<ItemController>().isTrap && dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.AddTrap(dropped.GetComponent<ItemController>().Trap);
                    dropped.GetComponent<DraggableItem>().isRemoved = false;
                }
                else if (!dropped.GetComponent<ItemController>().isTrap && dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.AddItem(dropped.GetComponent<ItemController>().Item);
                    dropped.GetComponent<DraggableItem>().isRemoved = false;
                }
            }
            else if (transform.name == "Inventory")
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                if (draggableItem != null)
                {
                    source.PlayOneShot(clip);
                    draggableItem.parentAfterDrag = transform.GetChild(0).GetChild(0);
                    draggableItem.GetComponent<Image>().color = new Color(draggableItem.GetComponent<Image>().color.r, draggableItem.GetComponent<Image>().color.g, draggableItem.GetComponent<Image>().color.b, 255);
                    draggableItem.GetComponentInChildren<TextMeshProUGUI>().color =
                        new Color(draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.r,
                        draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.g,
                        draggableItem.GetComponentInChildren<TextMeshProUGUI>().color.b, 255);
                }
                Debug.Log(draggableItem);

                if (dropped.GetComponent<ItemController>().isTrap && dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.AddTrap(dropped.GetComponent<ItemController>().Trap);
                    dropped.GetComponent<DraggableItem>().isRemoved = false;
                }
                else if (!dropped.GetComponent<ItemController>().isTrap && dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.AddItem(dropped.GetComponent<ItemController>().Item);
                    dropped.GetComponent<DraggableItem>().isRemoved = false;
                }
            }
        }        
    }
}
