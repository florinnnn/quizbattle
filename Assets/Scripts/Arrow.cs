using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 10f;
    public float arrowDamage = 10f;

    private GameObject targetEnemy;

    void Start()
    {
        FindClosestEnemy();
    }

    void Update()
    {
        if (targetEnemy != null)
        {
            Vector3 direction = (targetEnemy.transform.position - transform.position).normalized;

            transform.Translate(direction * arrowSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                targetEnemy = enemy;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Slider healthSlider = GetComponent<Slider>();

            if (enemy != null)
            {
                enemy.TakeDamage(arrowDamage);
                UpdateHealthBar(enemy, healthSlider);
            }
            Destroy(gameObject);
        }
    }

    void UpdateHealthBar(Enemy enemy, Slider healthSlider)
    {
        float healthPercentage = enemy.currentHealth / enemy.maxHealth;
        healthSlider.value = healthPercentage;
    }
}