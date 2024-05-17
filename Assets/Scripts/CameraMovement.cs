using UnityEngine;

public class CameraMover : MonoBehaviour
{
    // Array to store the predefined positions and rotations
    private Vector3[] positions = new Vector3[]
    {
        new Vector3(-33, 30, -30),
        new Vector3(33, 30, -30),
        new Vector3(33, 30, 30),
        new Vector3(-30, 30, 30)
    };

    private Vector3[] rotations = new Vector3[]
    {
        new Vector3(30, 47, 0),
        new Vector3(30, -47, 0),
        new Vector3(30, -132, 0),
        new Vector3(30, -225, 0)
    };

    // Index to keep track of the current position
    private int currentIndex = 0;

    // Define the speed at which the camera moves
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        // Initialize the target position and rotation
        targetPosition = positions[currentIndex];
        targetRotation = Quaternion.Euler(rotations[currentIndex]);
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }

    void Update()
    {
        if (isMoving)
        {
            // Smoothly move the camera towards the target position and rotation
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            // Check if the camera has reached the target position and rotation
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f &&
                Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.position = targetPosition;
                transform.rotation = targetRotation;
                isMoving = false; // Stop moving once the target is reached
            }
        }
    }

    public void MoveLeft()
    {
        // Move backwards in the list, wrapping around if necessary
        currentIndex = (currentIndex == 0) ? positions.Length - 1 : currentIndex - 1;
        SetTarget();
    }

    public void MoveRight()
    {
        // Move forwards in the list, wrapping around if necessary
        currentIndex = (currentIndex == positions.Length - 1) ? 0 : currentIndex + 1;
        SetTarget();
    }

    private void SetTarget()
    {
        // Set the new target position and rotation
        targetPosition = positions[currentIndex];
        targetRotation = Quaternion.Euler(rotations[currentIndex]);
        isMoving = true;
    }
}
