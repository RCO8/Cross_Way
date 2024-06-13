using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoving : MonoBehaviour
{
    Rigidbody2D rgdBody;

    Vector2 playerMovement = Vector2.zero;

    private void Awake()
    {
        rgdBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        rgdBody.velocity = playerMovement.normalized;
    }

    public void GetMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            playerMovement = context.ReadValue<Vector2>();
        else if(context.phase == InputActionPhase.Canceled)
            playerMovement = Vector2.zero;
    }
}
