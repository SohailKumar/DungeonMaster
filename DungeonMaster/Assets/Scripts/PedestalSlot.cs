using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PedestalSlot : MonoBehaviour, IDropHandler
{
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
            if (transform.childCount == 0)
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                if (draggableItem != null)
                {
                    draggableItem.parentAfterDrag = transform;
                }

                // Remove it from inventory
                if (dropped.GetComponent<ItemController>().isTrap && !dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.RemoveTrap(dropped.GetComponent<ItemController>().Trap);
                    dropped.GetComponent<DraggableItem>().isRemoved = true;
                    dropped.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                }
                else if (!dropped.GetComponent<ItemController>().isTrap && !dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.RemoveItem(dropped.GetComponent<ItemController>().Item);
                    dropped.GetComponent<DraggableItem>().isRemoved = true;
                    dropped.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                }
            }
            else if (transform.name == "Content")
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                if (draggableItem != null)
                {
                    draggableItem.parentAfterDrag = transform;
                }

                if (dropped.GetComponent<ItemController>().isTrap && dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.AddTrap(dropped.GetComponent<ItemController>().Trap);
                    dropped.GetComponent<DraggableItem>().isRemoved = false;
                    dropped.GetComponent<Image>().color = new Color(251 / 255f, 145 / 255f, 145 / 255f);
                }
                else if (!dropped.GetComponent<ItemController>().isTrap && dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.AddItem(dropped.GetComponent<ItemController>().Item);
                    dropped.GetComponent<DraggableItem>().isRemoved = false;
                    dropped.GetComponent<Image>().color = Color.white;
                }
            }
            else if (transform.name == "Inventory")
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                if (draggableItem != null)
                {
                    draggableItem.parentAfterDrag = transform.GetChild(0).GetChild(0);
                    Debug.Log("InvDriop");
                }
                Debug.Log(draggableItem);

                if (dropped.GetComponent<ItemController>().isTrap && dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.AddTrap(dropped.GetComponent<ItemController>().Trap);
                    dropped.GetComponent<DraggableItem>().isRemoved = false;
                    dropped.GetComponent<Image>().color = new Color(251 / 255f, 145 / 255f, 145 / 255f);
                }
                else if (!dropped.GetComponent<ItemController>().isTrap && dropped.GetComponent<DraggableItem>().isRemoved)
                {
                    InventoryManager.Instance.AddItem(dropped.GetComponent<ItemController>().Item);
                    dropped.GetComponent<DraggableItem>().isRemoved = false;
                    dropped.GetComponent<Image>().color = Color.white;
                }
            }
        }        
    }
}
