using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Transition")]
public sealed class Transition : ScriptableObject
{
    // Condition to be evaluated for transition to occur
    public Decision Decision;

    // State to transition to if condition is true
    public BaseState TrueState;

    // State to transition to if condition is false
    public BaseState FalseState;

    public void Execute(BaseStateMachine stateMachine)
    {
        // If decision is true, transition to TrueState, else transition to FalseState
        BaseState nextState = Decision.Decide(stateMachine) ? TrueState : FalseState;
        stateMachine.CurrentState = nextState;
    }
}
