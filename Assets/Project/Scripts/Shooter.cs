using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using InputManager;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSens;
    [SerializeField] private float aimsens;
    [SerializeField] private Transform bulletprojectile;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform spawnbullet;
    private ThirdPersonController thirdPersonController;
    private InputManager.InputController inputController;
    private Animator animator;
    private int reloadtime;
    private int magazinesize;
    public bool reloading=false;
    private int bulletsleft;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        inputController = GetComponent<InputManager.InputController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
        }
        if (inputController.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSens(aimsens);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSens(normalSens);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
        }
    }
}
