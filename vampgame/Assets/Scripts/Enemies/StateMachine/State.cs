using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[CreateAssetMenu(menuName = "State/State")]
public sealed class State : BaseState
{

    // List of actions to be executed when the state is entered
    public List<StateAction> Action = new List<StateAction>();
    // List of possible transitions from the instance of this state
    public List<Transition> Transitions = new List<Transition>();

    public override void Execute(BaseStateMachine stateMachine)
    {
        // Execute all actions and evaluate all transitions
        foreach (var action in Action)
        {
            action.Execute(stateMachine);
        }

        foreach (var transition in Transitions)
        {
            transition.Execute(stateMachine);
        }
    }
}

