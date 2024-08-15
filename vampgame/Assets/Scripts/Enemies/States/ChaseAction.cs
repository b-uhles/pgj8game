using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
using JetBrains.Annotations;
using Unity.VisualScripting;
using System;

[CreateAssetMenu(menuName = "State/Actions/ChaseAction")]
public class ChaseAction : StateAction
{

        public float speed = 5001.0f;
        public float stoppingDistance = 1.0f;   
        public float nextWaypointDistance = 3.0f;
        public float turnSpeed = 5.0f;
        public float distanceToTarget;

        Path path;
        int currentWaypoint = 0;
        bool reachedEndOfPath = false;
        Seeker seeker;
        Rigidbody2D rb;
        EnemySight enemySight;
        Vector2 previousTargetPosition;
        Vector2 targetPosition;


    public override void Execute(BaseStateMachine stateMachine)
    {
        enemySight = stateMachine.GetComponent<EnemySight>();
        seeker = stateMachine.GetComponent<Seeker>();
        rb = stateMachine.GetComponent<Rigidbody2D>();
        targetPosition = enemySight.Player.position;
        

        if (path == null || Vector2.Distance(targetPosition, previousTargetPosition) > 0.1f)
        {   
            seeker.StartPath(rb.position, enemySight.Player.position, OnPathComplete);
            previousTargetPosition = targetPosition;
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction =  ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        // Debug.Log((Vector2)path.vectorPath[currentWaypoint] + " " + rb.position);
        // Debug.Log(currentWaypoint);
        Vector2 force = direction * speed * Time.deltaTime;
        Debug.Log(speed);
        Debug.Log(force);
        rb.AddForce(force);
        // foreach (Vector3 waypoint in path.vectorPath)
        // {
        //     Debug.Log(waypoint);
        // }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
