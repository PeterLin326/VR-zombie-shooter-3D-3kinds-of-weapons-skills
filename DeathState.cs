using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : StateMachineBehaviour
{
    public float deathWaitTime = 1.5f;
    float timeCounter = 0.0f;
    public AudioSource musicD;
    public AudioClip ZombieD;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        musicD = animator.gameObject.AddComponent<AudioSource>();
        musicD.clip = ZombieD;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!musicD.isPlaying)
        {
            musicD.Play();
        }
        Destroy(animator.gameObject.GetComponent<MeshCollider>());

        timeCounter += Time.deltaTime;
        if(timeCounter > deathWaitTime)
        {
            Destroy(animator.gameObject);
            
            
            
            
        }
       
    }
}
