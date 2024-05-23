using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float maxHealth = 100f;
    public float currentHealth;
  
    void Start()
    {
        currentHealth = maxHealth;
       
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}