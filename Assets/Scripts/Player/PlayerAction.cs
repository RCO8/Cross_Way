using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    public int CoinScore { get; private set; } = 0;
    public float DistanceScore { get; private set; } = 0f;

    public void GetCoin(int coin)
    {
        CoinScore += coin;
        //Debug.Log($"Coin : {CoinScore}");
    }

    public void GetAction(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Debug.Log("Action");
        }
    }

    private void LateUpdate()
    {
        DistanceScore = transform.position.y;
    }
}
