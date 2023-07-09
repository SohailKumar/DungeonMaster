using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class TrapPlacementSlot : MonoBehaviour
{
    [SerializeField] public List<GameObject> upgrades = new List<GameObject>();
    [SerializeField] GameObject displayTrap;
    GameObject trap;
    bool hasGenerated = false;
    public int additionalAttack = 0;

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
        if (transform.childCount == 0)
        {
            Destroy(trap);
            hasGenerated = false;
        }

        additionalAttack = 0;
        foreach (GameObject obj in upgrades)
        {
            if (obj.transform.childCount > 0)
            {
                additionalAttack += obj.GetComponentInChildren<ItemController>().Item.AttackDamage;
            }
        }
    }

    void GenerateTrap()
    {
        
        displayTrap.GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).Find("Image").GetComponent<Image>().sprite;
        displayTrap.GetComponent<Animator>().runtimeAnimatorController = transform.GetComponentInChildren<ItemController>().Trap.animator;
        Trapper trapper = displayTrap.GetComponent<Trapper>();
        trapper.damage = transform.GetComponentInChildren<ItemController>().Trap.damage;
        trapper.attackSpeed = transform.GetComponentInChildren<ItemController>().Trap.atkSpeed;
       
        trapper.upgradeDmg = this;
        trap = Instantiate(displayTrap, new Vector3(Camera.main.ScreenToWorldPoint(transform.position).x+1.1f, Camera.main.ScreenToWorldPoint(transform.position).y + 1.63f), transform.rotation);
    }


}
