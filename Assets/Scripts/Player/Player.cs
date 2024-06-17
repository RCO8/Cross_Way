using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //플레이어가 갖고 있는 컴포넌트를 정리
    public PlayerAction action { get; set; }
    public Animation animation { get; private set; }
    public PlayerInputSystem input { get; private set; }


    private void Awake()
    {
        action = GetComponent<PlayerAction>();
        animation = GetComponent<Animation>();
        input = GetComponent<PlayerInputSystem>();
    }
}
