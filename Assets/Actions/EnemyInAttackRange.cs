using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class EnemyInAttackRange : ActionNode
{
    //player transform
    //own transform
    //range to check
    public NodeProperty<GameObject> selfGameObject, playerGameObject;
    public NodeProperty<float> upperrange;
    private Transform myTransform, playerTransform;
    public float attackdis;
    protected override void OnStart()
    {
        myTransform = selfGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
    }
    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        playerTransform = playerGameObject.Value.transform;
        if (Vector3.Distance(myTransform.position, playerTransform.position) <= attackdis)
        {
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
        
    }
}
