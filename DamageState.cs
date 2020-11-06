using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : StateMachineBehaviour
{
     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int hp = animator.GetInteger("Hp");
        hp--;
        animator.SetInteger("Hp", hp);
        if(hp <= 0)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
}