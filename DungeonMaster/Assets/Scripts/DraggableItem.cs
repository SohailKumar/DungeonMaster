using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] public Image image;
    [SerializeField] public Transform parentAfterDrag;
    public bool isTrap;
    public bool isRemoved;
    public bool canOpenPopup = true;

    private Canvas infoCard;

    private void Start()
    {
        infoCard = gameObject.transform.Find("InfoPopup").GetComponent<Canvas>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) && infoCard.transform.GetChild(0).gameObject.activeSelf)
        {
            PopupInfo(false);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            PopupInfo(true);
            Debug.Log("Right click");
    }

    private void PopupInfo(bool show)
    {
        if(canOpenPopup)
            infoCard.transform.GetChild(0).gameObject.SetActive(show);
    }
}
