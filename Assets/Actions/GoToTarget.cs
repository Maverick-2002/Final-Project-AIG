using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

[System.Serializable]
public class GoToTarget : ActionNode
{
    public NodeProperty<GameObject> selfGameObject, targetObject;
    private Transform myTransform, nextWavepointTransform;
    private Vector3 direction;
    private float speed = 0.03f;
    Animator anim;
    float timer=0;
    Transform player;
    NavMeshAgent agent;

    protected override void OnStart() {
        myTransform = selfGameObject.Value.transform;
        nextWavepointTransform = targetObject.Value.transform;
        anim = selfGameObject.Value.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = selfGameObject.Value.GetComponent<NavMeshAgent>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        timer += Time.deltaTime;

        if (timer > 1)
        {
            moveToTarget();
        }
        if (timer > 20)
        {
          
            timer= 0;

        }
        Debug.Log("Stop");
        anim.SetBool("Running", false);
        agent.speed = 0.3f;
        //  if (nextWavepointTransform != null)
        // {

        //     
        // }

        return State.Success;
    }

    void moveToTarget()
    {
       /*direction = nextWavepointTransform.position - myTransform.position;
        anim.SetBool("Walking", true);
        myTransform.Translate(direction * speed * Time.deltaTime);
        Debug.Log("Running");*/
       agent.SetDestination(nextWavepointTransform.position);
        
    }
}
