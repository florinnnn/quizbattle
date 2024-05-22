using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEnemyHealthBar : MonoBehaviour
{
    private Enemy enemy;
    private Slider healthSlider;

    void Start()
    {
        Transform wall = this.transform.parent.parent;

        enemy = wall.GetComponent<Enemy>();
        healthSlider = GetComponent<Slider>();
        UpdateHealthBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.TakeDamage(10);
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float healthPercentage = enemy.currentHealth / enemy.maxHealth;
        healthSlider.value = healthPercentage;
    }
}
