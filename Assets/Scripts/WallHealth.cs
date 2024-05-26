using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WallHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    
    public GameObject EndLose;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI healthScore;


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
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }



        GameObject healthBar = GameObject.Find("Castle/HealthCanva/HealthBar");
        Slider healthSlider = healthBar.GetComponent<Slider>();
        float healthPercentage = currentHealth / maxHealth;
        healthSlider.value = healthPercentage;

        healthScore.text = "Health " + currentHealth.ToString("0.00");
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthScore.text = "Health " + currentHealth.ToString("0.00");

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth == 0)
        {
            if(EndLose != null)
            {
                GameObject gameManager = GameObject.Find("GameManager");
                Counter counter = gameManager.GetComponent<Counter>();
                EndLose.SetActive(true);
                textScore.text = counter.countText.text;
                 
            }
            Destroy(gameObject);

        }
    }
}
