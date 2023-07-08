using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapPlacementSlot : MonoBehaviour
{
    [SerializeField] GameObject displayTrap;
    bool hasGenerated = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0 && !hasGenerated)
        {
            GenerateTrap();
            hasGenerated = true;
        }
    }

    void GenerateTrap()
    {
        displayTrap.GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).Find("Image").GetComponent<Image>().sprite;
        Instantiate(displayTrap, new Vector3(Camera.main.ScreenToWorldPoint(transform.position).x, Camera.main.ScreenToWorldPoint(transform.position).y + 1), transform.rotation);
    }


}
