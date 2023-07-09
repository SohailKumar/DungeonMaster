using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum Screen
    {
        Menu,
        Dungeon,
        SellShop,
        Battle
    }

    public Screen curScreen;

    [SerializeField]
    private GameObject currencyText;

    [SerializeField]
    public GameObject[] traps;
    public static List<GameObject> trapInventory = new List<GameObject>();
    public static List<GameObject> trapActive = new List<GameObject>();

    [SerializeField]
    private GameObject trapShop;
    private GameObject afterBattleScreen;
    //private static GameObject trapSelector;

    public static int enemiesLeft;
    public static int totalEnemies;
    public static TextMeshProUGUI enemyCounterText;

    public void Awake()
    {
        enemyCounterText = GameObject.Find("EnemyCounter").GetComponent<TextMeshProUGUI>();
        enemyCounterText.text = "";

        CurrencySystem.currencyText = GameObject.Find("CurrentMoney").GetComponent<TextMeshProUGUI>();
        CurrencySystem.Instance.addMoney(400);
        CurrencySystem.Instance.setMoneyText();

        if(curScreen == Screen.Dungeon)
        {
            
            trapShop = GameObject.Find("TrapShop");
            trapShop.SetActive(false);

            afterBattleScreen = GameObject.Find("AfterBattlePanel");
            afterBattleScreen.SetActive(false);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    public int TrapCheck(int trapNumber)
    {
        int sum = 0;
        string name = traps[trapNumber].name;
        foreach(GameObject j in trapInventory)
        {
            if(j.GetComponent<Trap>().trapname == name)
            {
                sum++;
            }
        }
        return sum;
    }

    public void OpenTrapShop()
    {
        trapShop.SetActive(true);
    }

    public void CloseTrapShop()
    {
        trapShop.SetActive(false);
    }

    public void StartBattle()
    {
        trapShop.SetActive(false);
        GameObject.Find("BuyButton").SetActive(false);
        //SET ANY NON BATTLE UI INACTIVE HERE!

        //start spawner
        int[] ar = { 1, 1, 1, 1 };
        GameObject.Find("Spawner").GetComponent<EnemySpawner>().StartSpawner(ar, 3);
    }
}
