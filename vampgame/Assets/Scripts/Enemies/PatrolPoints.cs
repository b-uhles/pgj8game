using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolPoints : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;
    public Transform CurrentPoint => _patrolPoints[_currentPointIndex];
    private int _currentPointIndex = 0;

    public Transform GetNext()
    {
        var point = _patrolPoints[_currentPointIndex];
        // increment the index and wrap around if necessary
        _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length;
        return point;
    }

    public bool HasReached(NavMeshAgent navMeshAgent)
    {
        if (!navMeshAgent.pathPending)
        {
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if(!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
