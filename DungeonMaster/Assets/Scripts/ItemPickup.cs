using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items item;
    public AudioSource source;
    public AudioClip pickupSound;

    void Pickup()
    {
        GameObject go = GameObject.Find("Canvas/InventoryManager");
        source = go.GetComponent<AudioSource>();
        source.PlayOneShot(InventoryManager.Instance.pickupSound);

        var ItemId = gameObject.GetComponent<ItemController>().Item;
        InventoryManager.Instance.AddItem(item);
        InventoryManager.Instance.ListItems();

        gameObject.SetActive(false);
        //Destroy(gameObject);

        if(Progression.roundNumber == 0)
        {
            OnboardingManager.Instance.DestroyOnboardingOne();
            OnboardingManager.Instance.DisplayOnboardingTwo();
        }
    }

    private void OnMouseDown()
    {
        Pickup();
    }

}
