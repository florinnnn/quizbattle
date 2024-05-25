using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    
    public GameObject EndLose;
    public TextMeshProUGUI textScore;

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
            if(EndLose != null)
            {
                EndLose.SetActive(true);
                textScore.text = Counter.countText.text;
                 
            }
            Destroy(gameObject);

        }
    }
}
