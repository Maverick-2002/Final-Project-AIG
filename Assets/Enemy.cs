using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   TheKiwiCoder.BehaviourTreeInstance behaviourTreeInstance;
    public GameObject waypointParent;
    public int health = 30;
    void Start()
    {
        behaviourTreeInstance = GetComponent<TheKiwiCoder.BehaviourTreeInstance>();
        behaviourTreeInstance.SetBlackboardValue("selfGameObject", gameObject);
        behaviourTreeInstance.SetBlackboardValue("waypointParent", waypointParent);
        behaviourTreeInstance.SetBlackboardValue("myTransform", gameObject);
        behaviourTreeInstance.SetBlackboardValue("playerGameObject", GameObject.FindGameObjectWithTag("Player"));
    }


    // Update is called once per frame
    void Update()
    {

    }
}
