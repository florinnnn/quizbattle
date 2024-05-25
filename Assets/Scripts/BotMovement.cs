using System.Collections;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    public float speed = 5f;
    public float stoppingDistance = 0.1f;

    private bool reachedTarget = false;
    private float despawnTimer = 3f;

    void Start()
    {
        // Set the target position to (0, 0, 0)
        targetPosition = Vector3.zero;
    }

    void Update()
    {
        // Move towards the target position
        MoveTowardsTarget();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Castle_objects")
        {
            speed = 0f;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            reachedTarget = true;
            StartCoroutine(DamageRoutine());
        }
    }

    IEnumerator DamageRoutine()
    {
        while (true)
        {
            TakeDamage(1f);
            yield return new WaitForSeconds(5f);
        }
    }

    void TakeDamage(float dmg)
    {   
        GameObject healthBar = GameObject.Find("Castle/HealthCanva/HealthBar");
        if (healthBar != null)
        {
            UpdateCastleHealthBar healthBarScript = healthBar.GetComponent<UpdateCastleHealthBar>();
            if (healthBarScript != null)
            {
                healthBarScript.TakeDamage(dmg);
            }
            else
            {
                Debug.LogError("UpdateCastleHealthBar script not found on HealthBar.");
            }
        }
        else
        {
            Debug.LogError("HealthBar GameObject not found.");
        }
    }

    void MoveTowardsTarget()
    {
        if (reachedTarget) return; // If bot reached target, don't move further

        // Calculate the direction towards the target
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Move the bot towards the target
        transform.position += moveDirection * Time.deltaTime * speed;

        // Optionally, you can rotate the bot to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        // Check if the bot has reached the target within the stopping distance
        if (Vector3.Distance(transform.position, targetPosition) <= stoppingDistance)
        {
            // Stop moving the bot
            speed = 0f;
            reachedTarget = true;
        }
    }
}
