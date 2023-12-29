using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
   public List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    public int chaserange;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer=0;
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("WayPoints");

        foreach (GameObject obj in waypointObjects)
        {
            waypoints.Add(obj.transform);
        }


        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance<=agent.stoppingDistance)
        {
            agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        }
        timer += Time.deltaTime;
        if (timer > 20)
        {
            animator.SetBool("Walking", false);
        }
        float dis= Vector3.Distance(animator.transform.position,player.position);
        if (dis < chaserange)
        {
            animator.SetBool("Running", true);
            agent.speed = 1.5f;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
