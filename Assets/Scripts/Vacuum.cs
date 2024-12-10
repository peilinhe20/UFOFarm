using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public float vacuumForce = 25f;
    public float destroyDistance = 2f;
    public float dampingFactor = 2f;    // Damping to reduce bouncing
    public float vacuumSpeed = 5f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Vacuumable")) // Tag vacuumable objects
        {
            // Apply force toward the UFO
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (transform.position - other.transform.position).normalized;
                rb.AddForce(direction * vacuumForce);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vacuumable")) // Ensure the object has the "Vacuumable" tag
        {
            // Calculate direction toward the UFO
            Vector3 direction = (transform.position - other.transform.position).normalized;

            // Move the object toward the UFO's position
            other.transform.position = Vector3.MoveTowards(
                other.transform.position,
                transform.position,
                vacuumSpeed * Time.deltaTime
            );

        }

    }
}
