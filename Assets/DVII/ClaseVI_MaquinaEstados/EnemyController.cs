using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
    private PatrolState patrolState;
    private ChaseState chaseState;
    private AttackState attackState;

    private State<EnemyController> currentState;

    public PatrolState PatrolState { get => patrolState;}
    public ChaseState ChaseState { get => chaseState;}
    public AttackState AttackState { get => attackState;}

    // Start is called before the first frame update
    void Start()
    {
        patrolState = GetComponent<PatrolState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();

        ChangeState(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        //Si tengo un estado el cual actualizar...
        currentState?.OnUpdateState(); //Pido que se atualice.
    }
    public void ChangeState(State<EnemyController> newState)
    {
        //Antes de cambiar, si est�bamos en un estado anterior...
        //Tendr� que salir de este estado.
        currentState?.OnExitState();

        //Y ahora mi estado actual es este.
        currentState = newState;

        //Por �ltimo, tendr� que pedir que este estado se inicie.
        currentState.OnEnterState(this);
    }
}
