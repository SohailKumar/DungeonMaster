using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndDestroy : MonoBehaviour
{
    [SerializeField] float deathTime;

    void Awake()
    {
        StartCoroutine("Sepukku");
    }

    IEnumerator Sepukku()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(this.gameObject);
    }

}
