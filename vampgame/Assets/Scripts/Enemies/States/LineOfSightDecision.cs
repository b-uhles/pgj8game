using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Decisions/LineOfSightDecision")]
public class LineOfSightDecision : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        var enemySight = stateMachine.GetComponent<EnemySight>();
        return enemySight.PlayerInSight();
    }
}
