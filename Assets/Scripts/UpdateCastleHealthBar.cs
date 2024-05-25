using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCastleHealthBar : MonoBehaviour
{
    private WallHealth wallHealth;
    private Slider healthSlider;
    public float healthPercentage;

    void Start()
    {
        healthPercentage = 100f;
        Transform wall = this.transform.parent.parent;

        wallHealth = wall.GetComponent<WallHealth>();
        healthSlider = GetComponent<Slider>();
        healthSlider.value = healthPercentage;
    }

    public void TakeDamage(float damage)
    { 
        wallHealth.TakeDamage(damage);
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        healthPercentage = wallHealth.currentHealth / wallHealth.maxHealth;
        healthSlider.value = healthPercentage;
    }

}
