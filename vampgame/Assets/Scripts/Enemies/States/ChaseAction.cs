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

        public float speed = 5.0f;
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


    public override void Execute(BaseStateMachine stateMachine)
    {
        enemySight = stateMachine.GetComponent<EnemySight>();
        seeker = stateMachine.GetComponent<Seeker>();
        rb = stateMachine.GetComponent<Rigidbody2D>();
        seeker.StartPath(rb.position, enemySight.Player.position, OnPathComplete);
        

        if (path == null)
            return;
        
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
        Vector2 force = direction * speed * Time.deltaTime;
        
        rb.AddForce(force);

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
