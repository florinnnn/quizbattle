using UnityEngine;

public class BotMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    public float speed = 5f;
    public float stoppingDistance = 0.1f; 

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

    void MoveTowardsTarget()
    {
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
        }

        // Optionally, you can rotate the bot to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }
}
