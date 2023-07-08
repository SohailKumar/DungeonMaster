using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingItems : MonoBehaviour
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

    public void OnBuy()
    {
        foreach (GameObject item in shopPedestals)
        {
            if (item.transform.childCount > 0)
            {
                //TODO: ADD SELLING LOGIC
                Debug.Log(item.transform.GetChild(0).GetComponent<ItemController>().Item.saleAmount);
                CurrencySystem.Instance.addMoney(item.transform.GetChild(0).GetComponent<ItemController>().Item.saleAmount);
                Destroy(item.transform.GetChild(0).gameObject);

                //Needs fix: Use Remove function of inventory manager to get rid of the item after sold so it 
                //Doesnt stay when the list is refreshed
                /*InventoryManager.Instance.Remove(item);*/
            }
        }
        Debug.Log(CurrencySystem.Instance.getMoney());
    }
}
