using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> Pedestals;

    public void ReturnToShop()
    {
        foreach (var item in Pedestals)
        {
            if (item.transform.childCount > 0)
            {
                if (item.transform.GetChild(0).GetComponent<ItemController>().isTrap)
                    InventoryManager.Instance.AddTrap(item.transform.GetChild(0).GetComponent<ItemController>().Trap);
                else
                    InventoryManager.Instance.AddItem(item.transform.GetChild(0).GetComponent<ItemController>().Item);
            }
        }

        InventoryManager.Instance.ListItems();
        SceneManager.LoadScene("GridDemo");
    }
}
