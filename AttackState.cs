using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform target;
    public float attackDelay = 0.5f;
    float timeCounter = 0.0f;
    public AudioSource musicA;
    public AudioClip ZombieA;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.Find("player").transform;
        musicA = animator.gameObject.AddComponent<AudioSource>();
        musicA.clip = ZombieA;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeCounter += Time.deltaTime;

        if(timeCounter > attackDelay)
        {

            if (!musicA.isPlaying)
            {
                musicA.Play();
            }
            timeCounter = 0.0f;
            GameObject.Find("player").GetComponent<PlayerState>().DamageByEnemy();
        }

        Vector3 dir = target.position - animator.transform.position;
        dir.y = 0;
        animator.transform.rotation = Quaternion.Lerp(animator.transform.rotation, Quaternion.LookRotation(dir), 200f * Time.deltaTime);

        if (dir.magnitude >= 2.5f)
        {
            animator.SetTrigger("Forward");
            return;
        }
    }
}
