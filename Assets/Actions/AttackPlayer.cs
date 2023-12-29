using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.UIElements;
using UnityEngine.AI;

[System.Serializable]
public class AttackPlayer : ActionNode
{
    public NodeProperty<GameObject> playerGameObject, selfGameObject;
    //private Animator anim;
    NavMeshAgent agent;
    Transform player;
    Animator anim;

    protected override void OnStart()
    {

        anim = selfGameObject.Value.GetComponent<Animator>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        selfGameObject.Value.transform.LookAt(player);
        float dis = Vector3.Distance(anim.transform.position, playerGameObject.Value.transform.position);
        if (dis < 3.1)
        {
            anim.SetBool("Running", false);
            anim.SetBool("Attacking", true);
            return State.Success;
        }
        else
        {
            anim.SetBool("Attacking", false);
            return State.Failure;
        }
        
    }

}
