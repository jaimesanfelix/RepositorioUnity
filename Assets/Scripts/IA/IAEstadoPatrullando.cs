using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEstadoPatrullando : StateMachineBehaviour
{
    private float tiempoPatrulla;
    private float tiempoPatrullando;
    private ControlEnemigo enemigo;    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("Patrullando...");
        tiempoPatrulla = Random.Range(10, 30);
        tiempoPatrullando = 0;
        enemigo = animator.gameObject.GetComponent<ControlEnemigo>();
        if (enemigo.alBorde)
            enemigo.Flip();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        enemigo.transform.Translate(enemigo.velocidad * Time.deltaTime, 0, 0);
        
        tiempoPatrullando += Time.deltaTime;
        if (tiempoPatrullando > tiempoPatrulla || enemigo.alBorde) {
            animator.SetTrigger("parar");
        } else if (enemigo.jugadorAtacable()) {
            animator.SetTrigger("atacar");
        }
    }

   

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
