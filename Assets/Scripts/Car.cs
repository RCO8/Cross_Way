using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float carSpeed = 10f;
    [SerializeField]
    Sprite[] CarSprite;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rgdBody2D;

    private Vector2 moveDirection = Vector2.zero;

    public void SetDirection(bool dir)
    {
        spriteRenderer.flipX = dir;
    }

    private void Awake()
    {
        rgdBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spriteRenderer.sprite = CarSprite[Random.Range(0, 2)];

        carSpeed = Random.Range(10f, 20f);

        if(spriteRenderer.flipX)    //우로 전진
            moveDirection = Vector2.right;
        else    //좌로 전진
            moveDirection = Vector2.left;
    }

    private void FixedUpdate()
    {
        rgdBody2D.velocity = moveDirection * carSpeed;

        if (Mathf.Abs(transform.position.x) > 13f)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("게임 오버");
        }
    }
}
