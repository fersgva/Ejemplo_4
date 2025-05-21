using System.Collections.Generic;
using DVII.ClaseVI_MaquinaEstados;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private float patrolSpeed;
    [SerializeField] private Transform route;
    
    private List<Transform> waypoints = new();
    
    private Transform currentWaypoint;
    private int currentWaypointIndex;
    public override void OnEnterState(FSM_Controller controller)
    {
        base.OnEnterState(controller);
        
        foreach (Transform point in route)
        {
            waypoints.Add(point);
        }
        currentWaypoint = waypoints[0];
    }

    public override void OnUpdateState()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, patrolSpeed * Time.deltaTime);

        if (transform.position == currentWaypoint.position)
        {
            CalculateNextWaypoint();
        }
    }

    private void CalculateNextWaypoint()
    {
        currentWaypointIndex++; //Subo uno al indice.
        currentWaypointIndex = currentWaypointIndex % waypoints.Count; //me aseguro de no salirme del total.
        currentWaypoint = waypoints[currentWaypointIndex]; //Actualizo el punto actual al cual debo de ir.
    }

    public override void OnExitState()
    {
        waypoints.Clear();
    }
}
