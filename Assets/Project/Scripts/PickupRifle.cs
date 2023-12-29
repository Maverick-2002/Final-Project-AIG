using InputManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRifle : MonoBehaviour
{
    [Header("Rifle's")] 
    public GameObject PlayerRifle;
    public GameObject PickupPlayerRifle;
    public PlayerPunch PlayerPunch;
    public GameObject rifleui;

    [Header("Rifle Assign Things")]
    public ThirdPersonController player;
    private float radius = 2.5f;
    public float nextTimeToPunch = 5f;
    public float punchCharge = 15f;

    public Animator animator;

    private void Awake()
    {
        PlayerRifle.SetActive(false);
        rifleui.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")&&Time.time > nextTimeToPunch)
        {
            animator.SetBool("Punch", true);
            nextTimeToPunch = Time.time +1f/punchCharge;
            PlayerPunch.Punch();

        }
        else
        {
            animator.SetBool("Punch", false);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if (Input.GetKey(KeyCode.P))
            {
                PlayerRifle.SetActive(true);
                PickupPlayerRifle.SetActive(false);
                //sound
                //objective completed
            }
        }
    }
}
