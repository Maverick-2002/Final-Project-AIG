using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public Camera cam;
    public float giveDamageOf = 10f;
    public float punchingRange = 5f;
    public GameObject effects;

    public void Punch()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, punchingRange))
        {
            Debug.Log(hit.transform.name);
            Target objectToHit = hit.transform.GetComponent<Target>();

            Target target = hit.transform.GetComponent<Target>();
            Zombie1 zombie1 = hit.transform.GetComponent<Zombie1>();
            if (zombie1 != null)
            {
                zombie1.zombiehitdamage(giveDamageOf);
            }
            GameObject impactGO = Instantiate(effects, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }
    }
}
