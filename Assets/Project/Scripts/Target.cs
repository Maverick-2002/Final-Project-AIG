using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float heath = 100000000000000000000000000000000f;
    public void TakeDamage( float damage)
    {
        heath -= damage;
        Debug.Log("Heath"+heath);
        if (heath <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
