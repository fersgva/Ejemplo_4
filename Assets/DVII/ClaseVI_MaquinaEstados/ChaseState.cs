using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State<EnemyController>
{
    private Transform target;
    [SerializeField] private float chaseVelocity;
    [SerializeField] private float stoppingDistance;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
    }
    public override void OnUpdateState()
    {
        if(target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, chaseVelocity * Time.deltaTime);
            if(Vector3.Distance(transform.position, target.position) <= stoppingDistance)
            {
                controller.ChangeState(controller.AttackState);
            }
        }
    }
    public override void OnExitState()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EjemploNameSpace.Player player))
        {
            target = player.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EjemploNameSpace.Player player))
        {
            controller.ChangeState(controller.PatrolState);
        }
    }


}
