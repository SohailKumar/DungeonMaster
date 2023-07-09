using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using static Unity.VisualScripting.Member;

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
    public static TextMeshProUGUI enemyCounterText;


    [SerializeField]
    public GameObject[] traps;
    public static List<GameObject> trapInventory = new List<GameObject>();
    public static List<GameObject> trapActive = new List<GameObject>();

    [SerializeField]
    private GameObject trapShop;
    private static GameObject afterBattleScreen;
    //private static GameObject trapSelector;

    public static AudioSource source;
    public AudioClip clip;
    public static AudioClip victoryclip;

    public static int enemiesLeft;
    public static int totalEnemies;
    public static TextMeshProUGUI buyButtonText;
    public static GameObject toBattleButton;
    public static InventoryButton inventoryButton;

    public string[] levels;

    public bool isBattling = false;
    public void Awake()
    {
        source = GameObject.Find("cavebg").GetComponent<AudioSource>();
        enemyCounterText = GameObject.Find("EnemyCounter").GetComponent<TextMeshProUGUI>();
        enemyCounterText.text = "";

        //CurrencySystem.currencyText = GameObject.Find("CurrentMoney").GetComponent<TextMeshProUGUI>();
        //CurrencySystem.Instance.addMoney(400);
        //CurrencySystem.Instance.setMoneyText();

        if(curScreen == Screen.Dungeon)
        {
            inventoryButton = GameObject.Find("OpenInventory").GetComponent<InventoryButton>();

            toBattleButton = GameObject.Find("Battle");
            toBattleButton.SetActive(true);
            
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

    public void OnLevelWasLoaded(int level)
    {
        isBattling = false;
    }

    public void ToggleTrapShop()
    {
        if(isBattling) 
        {
            return;
        }

        if (trapShop.activeSelf)
        {
            trapShop.SetActive(false);

            if(Progression.roundNumber == 0)
            {
                OnboardingManager.Instance.DisplayOnboardingFive();
            }
        }
        else
        {
            trapShop.SetActive(true);
            InventoryManager.Instance.gameObject.SetActive(false);
            inventoryButton.isActive = false;

            if(Progression.roundNumber == 0)
            {
                OnboardingManager.Instance.DisplayOnboardingFour();
            }
        }
    }
    public void StartBattle()
    {

        
        source.Stop();
        source.PlayOneShot(clip);
        toBattleButton.SetActive(false);
        trapShop.SetActive(false);
        InventoryManager.Instance.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        GameObject.Find("BuyButton").SetActive(false);
        isBattling = true;

        //start spawner
        string[] things = levels[Progression.roundNumber].Trim().Split(",");
        string spawnTiers = things[0];
        float spawnDelay = float.Parse(things[1]);
        

        int[] ar = {1,1};
        ar = Array.ConvertAll(spawnTiers.Trim().Split(" "), s => int.Parse(s));
        GameObject.Find("Spawner").GetComponent<EnemySpawner>().StartSpawner(ar, spawnDelay);

        Progression.roundNumber++;
    }

    public static void ReduceEnemies()
    {
        enemiesLeft--;
        enemyCounterText.text = enemiesLeft.ToString() + "/" + totalEnemies.ToString() + " Enemies";
        source.Stop();
        if (enemiesLeft == 0)
        {
            
            afterBattleScreen.SetActive(true);
        }
    }
}
