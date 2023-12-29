using InputManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f; public float fireRate = 15f;
    public float impactForce = 30f;
    public int Mammo = 10;
    public int Cammo;
    public float reloadtime = 3f;
    public bool isReloading = false;
    public Camera tpsCam;
    public Animator animator;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public int mag = 10;
    public Transform hand;
    public GameObject bloodeffects;
    public GameObject rifleui;
    public GameObject AmmoOutUI;
    public Text ammo;
    public Text magg;
    public AudioClip GunSound;
    public AudioSource GunSource;
    public AudioClip ReloadSound;
    public AudioSource ReloadSource;


    private float nextTimeToFire = 0f;
    void Start()
    {
        rifleui.SetActive(true);

        transform.SetParent(hand);
        Cammo = Mammo;

    }
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Reload");
            StartCoroutine(Reload());
            return;

        }
        if (Cammo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }
    IEnumerator Reload()
    {
        
        isReloading = true;
        Debug.Log("Reloading");
        animator.SetBool("Reloading", true);
        ReloadSource.PlayOneShot(ReloadSound);
        yield return new WaitForSeconds(reloadtime);
        animator.SetBool("Reloading", false);
        mag--;
        Cammo = Mammo;
        magg.text = "Magazines::" + mag;
        ammo.text = "Ammo::" + Cammo;
        isReloading = false;
    }

    IEnumerator AmmoOut()
    {
        AmmoOutUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        AmmoOutUI.SetActive(false);
    }
    void Shoot()
    {
        if (mag == 0)
        {
            ammo.text = "Ammo::" + "0";
            StartCoroutine(AmmoOut());
            return;
        }

        if (Cammo == 0)
        {
            mag--;
            magg.text = "Magazines::" + mag;
        }
        if (Input.GetButton("Aim"))
        {
            muzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                Zombie1 zombie1 = hit.transform.GetComponent<Zombie1>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                    GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, 2f);
                }
                else if (zombie1 != null)
                {
                    zombie1.zombiehitdamage(damage);
                    GameObject bloodeffect = Instantiate(bloodeffects, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(bloodeffect, 2f);
                }

              
            }
            Cammo--;
            ammo.text = "Ammo::" + Cammo;
            GunSource.PlayOneShot(GunSound);


        }

    }
}
