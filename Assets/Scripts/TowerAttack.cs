using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackCooldown = 1f;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;

    private GameObject targetEnemy;
    private float lastAttackTime;

    void Update()
    {
        if (targetEnemy != null && Time.time - lastAttackTime >= attackCooldown)
        {
            if (Vector3.Distance(transform.position, targetEnemy.transform.position) <= attackRange)
            {
                Attack();
            }
            else
            {
                targetEnemy = null;
            }
        }
        else
        {
            FindTarget();
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= attackRange && distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        targetEnemy = closestEnemy;
    }

    void Attack()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);

        Vector3 direction = (targetEnemy.transform.position - arrowSpawnPoint.position).normalized;

        Rigidbody arrowRigidbody = arrow.GetComponentInChildren<Rigidbody>();

        if (arrowRigidbody != null)
        {
            arrowRigidbody.velocity = direction * 2;
        }

        lastAttackTime = Time.time;
    }
}