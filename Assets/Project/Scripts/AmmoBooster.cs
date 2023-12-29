using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBooster : MonoBehaviour
{
    public Gun gun;
    int magg;
    private int magtogive = 5;
    private float radius = 2.5f;
    public Text mag;

  public AudioClip AmmoboostSound;
  public AudioSource AmmoboostSource;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, gun.transform.position) < radius)
        {
            if (Input.GetKeyDown("e"))
            {
                gun.mag += magtogive;
                magg=gun.mag;
                mag.text = "Magazines::" + magg;
                AmmoboostSource.PlayOneShot(AmmoboostSound);
                Object.Destroy(gameObject,1.5f);
            }
        }
    }
}
