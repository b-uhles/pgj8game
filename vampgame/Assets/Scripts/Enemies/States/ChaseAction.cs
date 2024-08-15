using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

[CreateAssetMenu(menuName = "State/Actions/ChaseAction")]
public class ChaseAction : StateAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        var enemySight = stateMachine.GetComponent<EnemySight>();

        navMeshAgent.SetDestination(enemySight.Player.position);
    }
}
