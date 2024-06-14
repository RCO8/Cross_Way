using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoving : MonoBehaviour
{
    public float PlayerSpeed = 7f;

    private PlayerAnimation playerAnimation;
    private Rigidbody2D rgdBody;

    private Vector2 playerMovement = Vector2.zero;
    private bool isMove = false;

    private void Awake()
    {
        rgdBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.isPlaying)
            Moving();
    }

    private void Moving()
    {
        rgdBody.velocity = playerMovement.normalized * PlayerSpeed;

        //애니메이션 적용
        playerAnimation.SetAnim(isMove, playerMovement.normalized);
    }

    public void GetMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            playerMovement = context.ReadValue<Vector2>();
            isMove = true;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            playerMovement = Vector2.zero;
            isMove = false;
        }
    }
}
