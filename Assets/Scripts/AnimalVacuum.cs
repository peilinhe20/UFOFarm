using UnityEngine;

public class AnimalVacuum : MonoBehaviour
{
    public Transform ufo;               // Public input for the UFO's transform
    public float pullSpeed = 3f;        // Speed at which the animal moves toward the UFO
    public float stopDistance = 0.5f;   // Distance to the UFO where the animal is destroyed
    public float squeezeFactor = 1f;  // Maximum squeezing effect (0.5 = 50% scale)
    private Vector3 originalScale;      // Store the sprite's original scale
    private AudioSource audioSource;    // Audio source for vacuum sound

    private bool isBeingVacuumed = false; // Flag to check if the animal is in the vacuum zone

    private void Start()
    {
        // Record the original scale of the sprite
        originalScale = transform.localScale;

        // Get the audio source component
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("VacuumZone")) // Detect when entering the vacuum zone
        {
            isBeingVacuumed = true;

            // Play the vacuum sound if audioSource is available
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("VacuumZone")) // Detect when exiting the vacuum zone
        {
            isBeingVacuumed = false;

            // Stop the vacuum sound if audioSource is available
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            // Reset the scale to its original value
            transform.localScale = originalScale;
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

            // Calculate distance to the UFO
            float distance = Vector3.Distance(transform.position, ufo.position);

            // Calculate squeezing based on proximity to the UFO
            float progress = Mathf.Clamp01(1 - (distance / stopDistance));
            float squeezeAmount = Mathf.Lerp(1f, squeezeFactor, progress);

            // Apply squeezing effect (squish horizontally and vertically)
            transform.localScale = new Vector3(
                originalScale.x * squeezeAmount, // Horizontal squeeze
                originalScale.y / squeezeAmount, // Vertical stretch
                originalScale.z                 // Maintain original depth
            );

            // Destroy the object if it reaches the UFO
            if (distance <= stopDistance)
            {
                Destroy(gameObject);
                Debug.Log($"{name} was vacuumed!");
            }
        }
    }
}
