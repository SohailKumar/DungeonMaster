using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PedestalSlot : MonoBehaviour, IDropHandler
{
    public enum DropAcceptType
    {
        Item,
        Trap
    }

    public DropAcceptType dropAcceptType = DropAcceptType.Item;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (dropped.GetComponent<ItemController>().isTrap && dropAcceptType == DropAcceptType.Trap
            || !dropped.GetComponent<ItemController>().isTrap && dropAcceptType == DropAcceptType.Item)
        {
            if (transform.childCount == 0 || transform.name == "Content")
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                if (draggableItem != null)
                {
                    draggableItem.parentAfterDrag = transform;
                }
            }
            else if (transform.name == "Inventory")
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                if (draggableItem != null)
                {
                    draggableItem.parentAfterDrag = transform.GetChild(0).GetChild(0);
                }
            }
        }        
    }
}
