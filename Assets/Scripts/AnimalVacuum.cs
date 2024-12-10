using UnityEngine;

public class AnimalVacuum : MonoBehaviour
{
    public Transform ufo;               // Public input for the UFO's transform
    public float pullSpeed = 3f;        // Speed at which the animal moves toward the UFO

    private bool isBeingVacuumed = false; // Flag to check if the animal is in the vacuum zone

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("VacuumZone")) // Detect when entering the vacuum zone
        {
            isBeingVacuumed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("VacuumZone")) // Detect when exiting the vacuum zone
        {
            isBeingVacuumed = false;
        }
    }

    private void Update()
    {
        if (isBeingVacuumed && ufo != null)
        {
            // Move toward the UFO's position
            transform.position = Vector3.MoveTowards(
                transform.position,         // Current position of the animal
                ufo.position,               // Target position (UFO)
                pullSpeed * Time.deltaTime  // Move at the specified speed
            );

            
        }
    }
}
