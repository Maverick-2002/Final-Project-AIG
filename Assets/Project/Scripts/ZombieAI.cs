using InputManager;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Zombie1 : MonoBehaviour
{
    public float giveDamge;
    public int zombiehealth;
    public float presenthealth;
    public UnityEngine.AI.NavMeshAgent zombieAgent;
    public Camera AttackingRaycastArea;
    public Transform playerbody;
    public LayerMask PlayerLayer;
    public Animator animator;   
    public GameObject[] walkPoints;
    public float zombieSpeed;
    float walkingpointRadius = 2;
    public float timebtwattack;
    bool lastattack;
    public float visionRadius;
    public float attackingRadius;
    public bool playerInvisionRadius;
    public bool playerInattackingRadius;
    public GameObject zombie;
    private void Awake()
    {
        presenthealth = zombiehealth;
        zombieAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, PlayerLayer);
        playerInattackingRadius = Physics.CheckSphere(transform.position, attackingRadius, PlayerLayer);
        if (playerInattackingRadius && playerInvisionRadius) Attackplayer();
    }
    private void Attackplayer()
    {
       // zombieAgent.SetDestination(transform.position);
        //transform.LookAt(LookPoint);
        if (!lastattack)
        {
            RaycastHit hit;
            if (Physics.Raycast(AttackingRaycastArea.transform.position,AttackingRaycastArea.transform.forward, out hit, attackingRadius))
            {
               
                Debug.Log("Attacking"+hit.transform.name);
                PlayerHealth shoot = hit.transform.GetComponent<PlayerHealth>();
                if (shoot != null)
                {
                    shoot.playerHitDamage(giveDamge);
                }
                lastattack = true;
                Invoke(nameof(ActiveAttacking), timebtwattack);
            }
           
        }
    }

    private void ActiveAttacking()
    {
        lastattack = false;
    }
    public void zombiehitdamage(float takeDamage)
    {
        presenthealth -= takeDamage;
        if (presenthealth <= 0)
        {
            animator.SetTrigger("Died");
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(zombie, 3f);
        }
        else
        {
            animator.SetTrigger("Hit");
            animator.SetBool("Running", true);
        }
    }
} 