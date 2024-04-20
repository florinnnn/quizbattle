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

        if (reachedTarget)
        {
            // Start the despawn timer
            despawnTimer -= Time.deltaTime;
            if (despawnTimer <= 0f)
            {
                // Despawn the bot after the timer reaches 0
                Destroy(gameObject);
            }
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
