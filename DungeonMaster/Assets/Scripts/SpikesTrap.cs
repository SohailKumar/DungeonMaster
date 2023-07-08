using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrap : Trap
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SPIKE ATTACK");
    }
}
