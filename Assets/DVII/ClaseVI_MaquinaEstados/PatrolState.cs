using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : State<EnemyController>
{
    [SerializeField] private Transform route;
    [SerializeField] private float velocidadPatrulla;

    private List<Vector3> listadoPuntos = new List<Vector3>();

    private Vector3 currentDestination;
    private int currentDestinationIndex;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
        foreach (Transform t in route)
        {
            //Establezco los puntos de ruta por los que pasa el murci�lago.
            listadoPuntos.Add(t.position);
        }

        currentDestination = listadoPuntos[currentDestinationIndex];

    }
    public override void OnUpdateState()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, velocidadPatrulla * Time.deltaTime);
        if(transform.position == currentDestination)
        {
            CalculateNewDestination();
        }
    }

    private void CalculateNewDestination()
    {
        currentDestinationIndex++;
        if(currentDestinationIndex > listadoPuntos.Count - 1)
        {
            currentDestinationIndex = 0;
        }

        currentDestination = listadoPuntos[currentDestinationIndex];
    }

    public override void OnExitState()
    {
        listadoPuntos.Clear();
        currentDestinationIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out EjemploNameSpace.Player player))
        {
            controller.ChangeState(controller.ChaseState);
        }
    }

}
