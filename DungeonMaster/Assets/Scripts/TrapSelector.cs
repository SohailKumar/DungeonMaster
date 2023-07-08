using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSelector : MonoBehaviour
{
    private Color startColor;
    [SerializeField] private TrapSelector trapSelector;

    private void Awake()
    {
        trapSelector = GameObject.Find("TrapSelector").GetComponent<TrapSelector>();
        startColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        
    }
}
