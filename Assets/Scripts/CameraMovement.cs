using UnityEngine;

public class CameraMover : MonoBehaviour
{
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

    private int currentIndex = 0;

    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        targetPosition = positions[currentIndex];
        targetRotation = Quaternion.Euler(rotations[currentIndex]);
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f &&
                Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.position = targetPosition;
                transform.rotation = targetRotation;
                isMoving = false;
            }
        }
    }

    public void MoveLeft()
    {
        currentIndex = (currentIndex == 0) ? positions.Length - 1 : currentIndex - 1;
        SetTarget();
    }

    public void MoveRight()
    {        currentIndex = (currentIndex == positions.Length - 1) ? 0 : currentIndex + 1;
        SetTarget();
    }

    private void SetTarget()
    {
        targetPosition = positions[currentIndex];
        targetRotation = Quaternion.Euler(rotations[currentIndex]);
        isMoving = true;
    }
}
