using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapInfo : MonoBehaviour
{
    [SerializeField] int trapNumber;
    [SerializeField] string trapName;
    [SerializeField] Trap trap;
    int trapPrice;
    int trapOwned;

    TextMeshProUGUI[] textObjects;

    GameManager gm;

    public void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        trapName = trap.trapname;
        trapPrice = trap.cost;
        trapOwned = gm.TrapCheck(trapNumber);

        textObjects = GetComponentsInChildren<TextMeshProUGUI>();
        textObjects[0].text = trapName;
        textObjects[1].text = "$"+trapPrice.ToString();
        textObjects[2].text = trapOwned.ToString();
    }
    
    public void Buy()
    {
        if(CurrencySystem.Instance.loseMoney(trapPrice) == true)
        {
            GameManager.trapInventory.Add(gm.traps[trapNumber]);
            trapOwned++;
            textObjects[2].text = trapOwned.ToString();
            CurrencySystem.Instance.setMoneyText();

            InventoryManager.Instance.AddTrap(trap);
            InventoryManager.Instance.ListItems();
        }
    }
}
