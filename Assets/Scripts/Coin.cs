using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int CoinScore = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.gameObject.TryGetComponent(out PlayerAction action))
            {
                action.GetCoin(CoinScore);
            }

            Destroy(gameObject);
        }
    }
}
