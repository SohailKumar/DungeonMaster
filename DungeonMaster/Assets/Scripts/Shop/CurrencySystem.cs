using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencySystem : GenericSingleton<CurrencySystem>
{
    private static int money;
    public List<Items> items = new List<Items>();
    public static TextMeshProUGUI currencyText;

    public void OnLevelWasLoaded(int level)
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.items = items;
            InventoryManager.Instance.ListItems();
        }
    }

    public void addMoney(int addAmount)
    {
        money += addAmount;
    }

    public bool loseMoney(int loseAmount)
    {
        if (money >= loseAmount)
        {
            money -= loseAmount;
            return true;
        }
        return false;
    }

    public int getMoney()
    {
        return money;
    }

    public void setMoneyText()
    {
        currencyText.text = "Money: $"+money.ToString();
    }

}
