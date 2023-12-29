using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using TMPro;
using UnityEngine.AI;
using System.Net;

[System.Serializable]
public class chasePlayer : ActionNode
{
    public NodeProperty<GameObject> selfGameObject, playerGameObject;
    public NodeProperty<float> upperRangeChase, lowerRangeChase;
    private Transform myTransform, playerTransform;
    private NavMeshAgent agent;
    private Animator anim;
    private float upperRange, lowerRange;
    public int chaserange;

    // private Vector3 playerGroundedTransform;

    private Vector3 direction;

   // private float rotationSpeed = 5f;
    protected override void OnStart()
    {
        myTransform = selfGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
        direction = playerTransform.position - myTransform.position;
        upperRange = upperRangeChase.Value;
        lowerRange = lowerRangeChase.Value;
        agent = selfGameObject.Value.GetComponent<NavMeshAgent>();
        anim = selfGameObject.Value.GetComponent<Animator>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        float dis = Vector3.Distance(selfGameObject.Value.transform.position, playerGameObject.Value.transform.position);
        if (dis <= chaserange)
        {
            ChasePlayer();
            return State.Success;
        }
        else
        {
            
            return State.Failure;
        }

    }

    void ChasePlayer()
    {
        anim.SetBool("Running", true);
        agent.speed = 0.9f;
        agent.SetDestination(playerTransform.position);
    }
}