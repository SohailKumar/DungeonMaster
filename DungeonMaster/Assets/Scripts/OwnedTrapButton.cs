  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OwnedTrapButton : MonoBehaviour
{
    [SerializeField] int trapNumber;
    [SerializeField] string trapName;

    TextMeshProUGUI[] textObjects;

    GameManager gm;

    public void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        Trap info = gm.traps[trapNumber].GetComponent<Trap>();
        trapName = info.trapname;

        textObjects = GetComponentsInChildren<TextMeshProUGUI>();
        textObjects[0].text = trapName;
    }
}
