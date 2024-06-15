using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    public int CoinScore { get; private set; } = 0;

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
}
