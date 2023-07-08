using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] traps;
    public List<GameObject> trapInventory;
    public List<GameObject> trapActive;

    public void Awake()
    {
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
}
