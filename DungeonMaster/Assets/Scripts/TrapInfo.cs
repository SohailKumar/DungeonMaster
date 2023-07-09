using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapInfo : MonoBehaviour
{
    [SerializeField] int trapNumber;
    [SerializeField] string trapName;
    [SerializeField] List<Trap> trapList;
    int trapPrice;

    TextMeshProUGUI[] textObjects;

    GameManager gm;
    int randomTrap;

    public void Awake()
    {
        randomTrap = Random.Range(0, trapList.Count);
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        trapName = trapList[randomTrap].trapname;
        trapPrice = trapList[randomTrap].cost;

        textObjects = GetComponentsInChildren<TextMeshProUGUI>();
        textObjects[0].text = trapName;
        textObjects[1].text = "$"+trapPrice.ToString();
    }
    
    public void Buy()
    {
        if(CurrencySystem.Instance.loseMoney(trapPrice) == true)
        {
            GameManager.trapInventory.Add(gm.traps[trapNumber]);
            CurrencySystem.Instance.setMoneyText();

            InventoryManager.Instance.AddTrap(trapList[randomTrap]);
            InventoryManager.Instance.ListItems();
        }
    }
}
