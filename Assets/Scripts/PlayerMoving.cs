using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoving : MonoBehaviour
{
    public float PlayerSpeed = 3f;

    private PlayerAnimation playerAnimation;
    private Rigidbody2D rgdBody;

    private Vector2 playerMovement = Vector2.zero;

    private void Awake()
    {
        rgdBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Start()
    {

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
        playerAnimation.SetAnim(playerMovement.normalized);
    }

    public void GetMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            playerMovement = context.ReadValue<Vector2>();
        else if(context.phase == InputActionPhase.Canceled)
            playerMovement = Vector2.zero;
    }
}
