using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vacuumable")) // Ensure the object has the "Vacuumable" tag
        {
            Destroy(other.gameObject); // Destroy the object
            Debug.Log($"{other.name} reached the UFO and was destroyed!");
            // Optional: Add effects, score increase, or sound here
        }
    }
}
