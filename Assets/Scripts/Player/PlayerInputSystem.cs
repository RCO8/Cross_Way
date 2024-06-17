using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    public PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnEnterMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (playerInput.currentActionMap.name == "Option")
                GameManager.Instance.OpenMenu(false);
            else
                GameManager.Instance.OpenMenu(true);
        }
    }
}
