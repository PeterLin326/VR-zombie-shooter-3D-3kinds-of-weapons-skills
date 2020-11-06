using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelState : StateMachineBehaviour
{
    float stateTime = 0;
    public float idleStateMaxTime = 2.0f;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateTime += Time.deltaTime;
        if(stateTime > idleStateMaxTime)
        {
            stateTime = 0;
            animator.SetTrigger("Forward");
        }
    }


}
