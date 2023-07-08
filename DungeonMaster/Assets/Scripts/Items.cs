using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Item/Create New Item")]

public class Items : ScriptableObject
{
    // Start is called before the first frame update
    public string itemName = "";
    public int saleAmount;
    public Sprite image;
    public int AttackDamage;
    public int Defense;
    public string flavortext = "";

}
