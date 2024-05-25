using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetDamage(float amount)
    {
        currentHealth += amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
