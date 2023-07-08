using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingItems : MonoBehaviour
{
    [SerializeField] List<GameObject> shopPedestals = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSell()
    {
        Debug.Log("Selling...");
        foreach (GameObject item in shopPedestals)
        {
            if (item.transform.childCount > 0)
            {
                Debug.Log("SOLD!!!");
                //TODO: ADD SELLING LOGIC

                Destroy(item.transform.GetChild(0).gameObject);
            }
        }
    }
}
