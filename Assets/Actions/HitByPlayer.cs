using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class HitByPlayer : ActionNode
{
    public float damage;
    public Zombie1 zombiehealth;

    protected override void OnStart() {

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        return State.Success;
    }
}
