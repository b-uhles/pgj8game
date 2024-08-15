using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Transform Player { get; private set; }
    public float activateDistance = 10f;
    [SerializeField] private LayerMask _ignoreMask;

    // ray to cast from enemy to player
    private Ray _ray;

    private void Awake()
    {
        // store a reference to the player's transform
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // is the player in sight?
    public bool PlayerInSight()
    {
        // if player does not exist, return false
        if (Player == null)
            return false;

        // create a ray from enemy to player
        _ray = new Ray(this.transform.position, Player.position - this.transform.position);

        // store direction and angle of ray
        var direction = new Vector3(_ray.direction.x, 0, _ray.direction.z);
        var angle = Vector3.Angle(direction, this.transform.forward);

        // TODO: add a check for distance and line of sight angle
        //if (angle too steep OR distance too far)
            //return false;

        // if ray does not hit anything, return false
        if(!Physics.Raycast(_ray, out var hit, 100, ~_ignoreMask))
            return false;

        // if ray hits player, return true
        if(hit.collider.tag == "Player")
            return true;

        return false;
    }

    // quick and dirty visualizer for raycast
//     private void OnDrawGizmos()
//     {
//         Gizmos.color = Color.red;
//         Gizmos.DrawRay(this.transform.position, Player.position - this.transform.position);
//         Gizmos.color = Color.green;
//         Gizmos.DrawLine(_ray.origin, _ray.origin + _ray.direction * 100);
//     }
}
