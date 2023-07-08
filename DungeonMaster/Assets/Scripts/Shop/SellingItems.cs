using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        foreach (GameObject item in shopPedestals)
        {
            if (item.transform.childCount > 0)
            {
                //TODO: ADD SELLING LOGIC
                Debug.Log(item.transform.GetChild(0).GetComponent<ItemController>().Item.saleAmount);
                CurrencySystem.Instance.addMoney(item.transform.GetChild(0).GetComponent<ItemController>().Item.saleAmount);
                Destroy(item.transform.GetChild(0).gameObject);

                //Deletes Item from InventoryManager
                Items deletedItem = item.transform.GetChild(0).GetComponent<ItemController>().Item;
                InventoryManager.Instance.Remove(deletedItem);
            }
        }
        Debug.Log(CurrencySystem.Instance.getMoney());
        LoadDungeonScene();
    }

    private void LoadDungeonScene()
    {
        InventoryManager.Instance.InventorySizeForScene(new Vector2(800, 510), new Vector2(190, 100));
        SceneManager.LoadScene("BattlerScene");
    }
}
