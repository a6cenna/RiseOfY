using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    private int rand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("isDead"))
        {
            return;
        }

        rand = Random.Range(0, 7);

        if (rand == 0 || rand == 1)
        {
            animator.SetTrigger("Run");
            Debug.Log("lari");
        }
        else if (rand == 2 || rand == 3)
        {
            animator.SetTrigger("Shoot");
        }
        else if (rand == 4 || rand == 5)
        {
            animator.SetTrigger("LShoot");
        }
        else if (rand == 6)
        {
            animator.SetTrigger("Skill");
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
