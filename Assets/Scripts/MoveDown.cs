using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float moveSpeed = 1f; // Speed of movement
    public float moveDistance = 5f; // Distance to move down

    private float startY; // Starting Y position
    private bool isMoving = true;

    private void Start()
    {
        startY = transform.position.y;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the object down
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;

            // Check if the object has moved the specified distance
            if (transform.position.y <= startY - moveDistance)
            {
                isMoving = false; // Stop moving
            }
        }
    }
}

