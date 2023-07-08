using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Screen
    {
        Menu,
        Dungeon,
        SellShop
    }

    public Screen curScreen;

    [SerializeField]
    public GameObject[] traps;
    public List<GameObject> trapInventory;
    public List<GameObject> trapActive;

    [SerializeField]
    private GameObject trapShop;

    public void Awake()
    {
        if(curScreen == Screen.Dungeon)
        {
            trapShop = GameObject.Find("TrapShop");
            trapShop.SetActive(false);
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
}
