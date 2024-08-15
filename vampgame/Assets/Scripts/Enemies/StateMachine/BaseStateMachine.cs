using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    [SerializeField] private BaseState  _initialState;
    // Caching components for performance (lol)
    private Dictionary<Type, Component> _components;
    public BaseState CurrentState { get; set; }

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // set the current state to the initial state
        CurrentState = _initialState;
        _components = new Dictionary<Type, Component>();
    }
    void Update()
    {
        // Execute the current state every frame
        CurrentState.Execute(this);
    }

    // overrides base unity GetComponent method
    public new T GetComponent<T>() where T : Component
    {
        // if component is already cached, return it
        if (_components.ContainsKey(typeof(T)))
            return _components[typeof(T)] as T;
            
        //otherwise, get the component using base method
        var component = base.GetComponent<T>();

        // if component exists, cache it
        if(component != null)
            _components.Add(typeof(T), component);

        return component;
    }
}
