using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCastleHealthBar : MonoBehaviour
{
    private WallHealth wallHealth;
    private Slider healthSlider;

    void Start()
    {
        Transform wall = this.transform.parent.parent;

        wallHealth = wall.GetComponent<WallHealth>();
        healthSlider = GetComponent<Slider>();
        UpdateHealthBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wallHealth.TakeDamage(10f);
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float healthPercentage = wallHealth.currentHealth / wallHealth.maxHealth;
        healthSlider.value = healthPercentage;
    }
}
