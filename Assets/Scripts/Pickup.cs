using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum PickupType
{
    Coin,
    Health
}
public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (type == PickupType.Coin)
            {
                collision.GetComponent<Player>().AddCoins(value);
                Destroy(gameObject);
            }
            else if (type == PickupType.Health)
            {
                if (collision.GetComponent<Player>().AddHealth(value))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    
}
