using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour
{
    public GameObject TargetLocation;
    public float speed = 0.05f;

    private float waitTimer = 0f;

    private enum BuyingMovement
    {
        FirstUp,
        SideMoveLeft,
        SideMoveRight,
        SecondUp,
        WaitingToBuy,
        Bought
    }
    BuyingMovement buyingMovement = BuyingMovement.FirstUp;

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (buyingMovement)
        {
            case BuyingMovement.FirstUp:
                if (transform.position.y < -4)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + speed);
                }
                else
                {
                    if (transform.position.x < TargetLocation.transform.position.x)
                        buyingMovement = BuyingMovement.SideMoveLeft;
                    else
                        buyingMovement = BuyingMovement.SideMoveRight;
                }
                break;
            case BuyingMovement.SideMoveLeft:
                if (transform.position.x < TargetLocation.transform.position.x)
                    transform.position = new Vector2(transform.position.x + speed, transform.position.y);
                else
                    buyingMovement = BuyingMovement.SecondUp;
                break;
            case BuyingMovement.SideMoveRight:
                if (transform.position.x > TargetLocation.transform.position.x)
                    transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                else
                    buyingMovement = BuyingMovement.SecondUp;
                break;
            case BuyingMovement.SecondUp:
                if (transform.position.y < TargetLocation.transform.position.y)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + speed);
                }
                else
                    buyingMovement = BuyingMovement.WaitingToBuy;
                break;
            case BuyingMovement.WaitingToBuy:
                waitTimer += Time.deltaTime;
                if (waitTimer > 5)
                    buyingMovement = BuyingMovement.Bought;
                break;
            case BuyingMovement.Bought:
                transform.position = new Vector2(transform.position.x, transform.position.y - speed);
                break;
        }
    }
}
