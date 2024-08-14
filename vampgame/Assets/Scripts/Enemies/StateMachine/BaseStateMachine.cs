using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    [SerializeField] private BaseState  _initialState;
    public BaseState CurrentState { get; set; }

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // set the current state to the initial state
        CurrentState = _initialState;
    }
    void Update()
    {
        // Execute the current state every frame
        CurrentState.Execute(this);
    }
}
