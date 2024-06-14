using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float CarSpeed = 10f;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rgdBody2D;

    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        rgdBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if(spriteRenderer.flipX)    //우로 전진
            moveDirection = Vector2.right;
        else    //좌로 전진
            moveDirection = Vector2.left;
    }

    private void FixedUpdate()
    {
        rgdBody2D.velocity = moveDirection * CarSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("게임 오버");
        }
    }
}
