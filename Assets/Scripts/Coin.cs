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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3) //Car¿Í ºÎ‹HÈù´Ù¸é
        {
            if(collision.transform.position.x > transform.position.x)
                transform.Translate(-1f, 0, 0);
            else
                transform.Translate(1f, 0, 0);
        }
    }
}
