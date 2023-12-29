using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject health;
    public float playerhealth;
    public HealthBar healthbar;
    public AudioClip healthSound;
    public AudioSource healthSource;
    public Animator animator;

    public void Start()
    {
        healthbar.GiveFullHealth(playerhealth);
    }
    public void playerHitDamage(float damage)
    {
        playerhealth -= damage;
        StartCoroutine(PlayerDamge());

        healthbar.SetHealth(playerhealth);
        if (playerhealth <= 0)
        {
            PlayerDie();
        }
        
    }
    private void PlayerDie()
    {
        animator.SetTrigger("Died");
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject,3.0f);
        SceneManager.LoadScene(2);

    }
    IEnumerator PlayerDamge()
    {
        health.SetActive(true);
        healthSource.PlayOneShot(healthSound);
        yield return new WaitForSeconds(1.8f);
        health.SetActive(false);
    }
}
