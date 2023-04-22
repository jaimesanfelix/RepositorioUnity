using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEstadoAtacando : StateMachineBehaviour
{
    private ControlEnemigo enemigo;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("Atacando...");
        enemigo = animator.gameObject.GetComponent<ControlEnemigo>();

        bool jugadorALADerecha = enemigo.jugador.transform.position.x >= enemigo.transform.position.x;
        bool jugadorALAIzquierda = !jugadorALADerecha;

        if ( jugadorALADerecha && enemigo.dirActual == ControlEnemigo.Direccion.IZQUIERDA
            || jugadorALAIzquierda && enemigo.dirActual == ControlEnemigo.Direccion.DERECHA) {
            //Debug.Log("Cambiando de direccion");
            enemigo.Flip();
        }        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks 
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(!enemigo.jugadorAtacable()) {
            animator.SetTrigger("parar");
        } else {
            enemigo.transform.Translate(enemigo.velocidad * Time.deltaTime, 0, 0);
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
