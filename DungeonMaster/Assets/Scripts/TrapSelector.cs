using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSelector : MonoBehaviour
{
    private Color startColor;
    [SerializeField] private GameObject trapSelector;

    private void Awake()
    {
        trapSelector = GameObject.Find("TrapSelectorUI");
        startColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = startColor;
    }

    private void OnMouseDown()
    {
        trapSelector.SetActive(true);
        GetComponent<SpriteRenderer>().color = Color.green;
    }
   
}
