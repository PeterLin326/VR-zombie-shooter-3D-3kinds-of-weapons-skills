using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardState : StateMachineBehaviour
{
    Transform target;    

    public float speed = 100.0f;
    public float rotationSpeed = 10.0f;   
    CharacterController _controller;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        target = GameObject.Find("FirstPersonCharacter").transform;     
        _controller = animator.gameObject.GetComponent<CharacterController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
        Vector3 dir = target.position - animator.transform.position;      
        float distance = dir.magnitude;
        if(distance < 2.5f)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            dir.y = 0f;
            
            _controller.SimpleMove(dir * speed * Time.deltaTime / distance);
            animator.transform.rotation = Quaternion.Lerp(animator.transform.rotation,Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
        }
    }
}
