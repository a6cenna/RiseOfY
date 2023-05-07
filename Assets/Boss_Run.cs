using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    private Transform playerPos;
    private Rigidbody2D rb;
    Boss boss;
    public float timer1;
    public float timer2;
    private float timer;

    public float speed;
    public float attackRange = 1f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        timer = Random.Range(timer1, timer2); 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("Run"))
        {
            Vector2 target = new Vector2(playerPos.position.x, rb.position.y);
            Vector2 newPos =  Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            boss.LookAtPlayer();

            if (Vector2.Distance(playerPos.position, rb.position) <= attackRange && timer >0)
            {
                animator.SetTrigger("Attack");
                animator.SetBool("Run", false);
                
            }
            else if(timer <=0)
            {
                animator.SetTrigger("Attack");
                animator.SetBool("Run", false);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
