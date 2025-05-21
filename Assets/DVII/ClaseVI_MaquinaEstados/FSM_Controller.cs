using System;
using DVII.ClaseVI_MaquinaEstados;
using UnityEngine;

public class FSM_Controller : MonoBehaviour
{
    private State currentState;

    private PatrolState patrolState;
    private ChaseState chaseState;
    private AttackState attackState;
    private void Awake()
    {
        patrolState = GetComponent<PatrolState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();
        
        currentState = patrolState;
        currentState.OnEnterState(this);
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.OnUpdateState();
            
        }
    }

    public void ChangeState(State newState)
    {
        if(currentState != null)
        {
            currentState.OnExitState();
        }
        currentState = newState;
        currentState.OnEnterState(this);
    }
}
