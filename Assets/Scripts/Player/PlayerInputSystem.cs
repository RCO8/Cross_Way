using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

    }

    public void OnEnterMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (playerInput.defaultActionMap == "Option")
            {
                playerInput.defaultActionMap = "Player";
                GameManager.Instance.OpenMenu(false);
            }
            else
            {
                playerInput.defaultActionMap = "Option";
                GameManager.Instance.OpenMenu(true);
            }
        }
    }
}
