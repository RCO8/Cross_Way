using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�÷��̾ ���� �ִ� ������Ʈ�� ����
    public PlayerAction action { get; set; }
    public Animation animation { get; private set; }


    private void Awake()
    {
        action = GetComponent<PlayerAction>();
        animation = GetComponent<Animation>();
    }
}
