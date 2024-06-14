using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void SetAnim(Vector2 direction)
    {
        animator.SetFloat("HorizonMove", direction.x);
        if (direction.x == 0)    //�¿� Ű�� 0�� �����̸�
            animator.SetFloat("VerticalMove", direction.y);
        else
            animator.SetFloat("VerticalMove", 0);
    }
}
