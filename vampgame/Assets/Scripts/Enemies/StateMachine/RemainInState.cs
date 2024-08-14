using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/RemainInState")]

// Class is sealed so that it can't be inherited from
// Empty so that the state machine will remain in the current state
public sealed class RemainInState : BaseState
{
}
