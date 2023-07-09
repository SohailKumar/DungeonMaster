using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Button inventoryButton;
    GameObject inventory;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = InventoryManager.Instance.gameObject;
        inventory.SetActive(false);
        InventoryManager.Instance.InventorySizeForScene(new Vector2(990, 84), new Vector2(160, 130));
        InventoryManager.Instance.gameObject.GetComponentInChildren<Image>().color = new Color(255, 255, 255, 125);

        if(Progression.roundNumber == 0)
        {
            OnboardingManager.Instance.DisplayOnboardingThree();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().isBattling)
            this.gameObject.SetActive(false);
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
