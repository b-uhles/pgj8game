using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : ScriptableObject
{
    // base state that can be inherited and overwritten by any other state, intent is to override the execute method
    public virtual void Execute(BaseStateMachine stateMachine)
    {
        
    }
}
