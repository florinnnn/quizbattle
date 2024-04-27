using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 10f;
    public int arrowDamage = 10;

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
            if (enemy != null)
            {
                enemy.TakeDamage(arrowDamage);
            }
            Destroy(gameObject);
        }
    }
}