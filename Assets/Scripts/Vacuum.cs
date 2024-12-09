using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public float vacuumForce = 25f;
    public float destroyDistance = 2f;
    public float dampingFactor = 2f;    // Damping to reduce bouncing

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
        if (other.CompareTag("Vacuumable")) // Ensure object has the "Vacuumable" tag
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Calculate direction toward the UFO
                Vector2 direction = (transform.position - other.transform.position).normalized;

                // Gradually move the object toward the UFO using AddForce
                rb.AddForce(direction * vacuumForce, ForceMode2D.Force);

                // Apply damping to smooth out motion
                rb.velocity = rb.velocity * (1 - Time.fixedDeltaTime * dampingFactor);

                // Destroy the object when it gets close enough
                if (Vector2.Distance(transform.position, other.transform.position) < destroyDistance)
                {
                    Destroy(other.gameObject);
                    Debug.Log($"{other.name} was vacuumed!");
                }
            }
        }
    }

}
