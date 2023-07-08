using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Button inventoryButton;
    GameObject inventory;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = InventoryManager.Instance.gameObject;
        inventory.SetActive(false);
        InventoryManager.Instance.InventorySizeForScene(new Vector2(982, 940), new Vector2(146, 130));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (!isActive)
        {
            inventory.SetActive(true);
            isActive = true;
        }
        else
        {
            inventory.SetActive(false);
            isActive = false;
        }
        
    }
}
