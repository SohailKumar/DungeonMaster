using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapInfo : MonoBehaviour
{
    [SerializeField] int trapNumber;
    [SerializeField] string trapName;
    int trapPrice;
    int trapOwned;

    [SerializeField] TextMeshProUGUI textCurrency;

    TextMeshProUGUI[] textObjects;

    GameManager gm;

    public void Awake()
    {
        textCurrency.text = CurrencySystem.Instance.getMoney().ToString();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        Trap info = gm.traps[trapNumber].GetComponent<Trap>();
        trapName = info.trapname;
        trapPrice = info.cost;
        trapOwned = gm.TrapCheck(trapNumber);

        textObjects = GetComponentsInChildren<TextMeshProUGUI>();
        Debug.Log(trapName + trapPrice.ToString());
        textObjects[0].text = trapName;
        textObjects[1].text = trapPrice.ToString();
        textObjects[2].text = trapOwned.ToString();
    }
    
    public void Buy()
    {
        if(CurrencySystem.Instance.loseMoney(trapPrice) == true)
        {
            gm.trapInventory.Add(gm.traps[trapNumber]);
            trapOwned++;
            textObjects[2].text = trapOwned.ToString();
        }
    }
}
