using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void SetAnim(bool move, Vector2 direction)
    {
        animator.SetBool("isMoving", move);

        if (move)
        {
            animator.SetFloat("HorizonMove", direction.x);
            if (direction.x == 0)    //좌우 키가 0인 상태이면
                animator.SetFloat("VerticalMove", direction.y);
            else
                animator.SetFloat("VerticalMove", 0);
        }
    }
}
