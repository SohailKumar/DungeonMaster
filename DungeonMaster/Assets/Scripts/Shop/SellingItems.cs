using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SellingItems : MonoBehaviour
{
    [SerializeField] List<GameObject> shopPedestals = new List<GameObject>();
    [SerializeField] Sprite moneyDrop;

    private float loadTimer = -10f;

    private void Awake()
    {
        GameObject inventory = InventoryManager.Instance.gameObject;
        inventory.SetActive(true);
        InventoryManager.Instance.InventorySizeForScene(new Vector2(1000, 920), new Vector2(160, 208));
        InventoryManager.Instance.gameObject.GetComponentInChildren<Image>().color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadTimer > -5)
        {
            loadTimer -= Time.deltaTime;
            if(loadTimer < 0f)
            {
                LoadDungeonScene();
            }
        }
    }

    public void OnSell()
    {
        foreach (GameObject item in shopPedestals)
        {
            if (item.transform.childCount > 0)
            {
                //TODO: ADD SELLING LOGIC
                //Debug.Log(item.transform.GetChild(0).GetComponent<ItemController>().Item.saleAmount);
                CurrencySystem.Instance.addMoney(item.transform.GetChild(0).GetComponent<ItemController>().Item.saleAmount);

                GameObject money = new GameObject();
                money.transform.parent = transform.parent;
                Image renderer = money.AddComponent<Image>();
                money.transform.position = item.transform.GetChild(0).position;
                renderer.sprite = moneyDrop;
                renderer.transform.localScale = new Vector2(0.4f, .4f);

                Destroy(item.transform.GetChild(0).gameObject);

                //Deletes Item from InventoryManager
                Items deletedItem = item.transform.GetChild(0).GetComponent<ItemController>().Item;
                InventoryManager.Instance.RemoveItem(deletedItem);
            }
        }
        Debug.Log(CurrencySystem.Instance.getMoney());
        loadTimer = 2f;
    }

    private void LoadDungeonScene()
    {
        //InventoryManager.Instance.InventorySizeForScene(new Vector2(800, 510), new Vector2(190, 100));
        SceneManager.LoadScene("BattlerScene");
    }
}
