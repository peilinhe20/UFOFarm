using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public float vacuumForce = 25f;
    public float dampingFactor = 2f;    // Damping to reduce bouncing
    public float vacuumSpeed = 5f;
    public List<AnimalPair> correctPairs;
    private AudioSource vacuumAudio;
    private List<string> vacuumedAnimals = new List<string>();

    [System.Serializable]
    public struct AnimalPair
    {
        public string animal1;
        public string animal2;
    }
    void Start()
    {
        // Get the AudioSource component attached to the object
        vacuumAudio = GetComponent<AudioSource>();
    }
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
            vacuumAudio.Play();
            string animalName = other.gameObject.name;

            // Add to the vacuumed animals list
            vacuumedAnimals.Add(animalName);
            Debug.Log("vacuumed animal added!");
            // Check for a valid pair
            CheckForPair(animalName);
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
    private void CheckForPair(string newAnimal)
    {
        foreach (var pair in correctPairs)
        {
            if ((pair.animal1 == newAnimal && vacuumedAnimals.Contains(pair.animal2)) ||
                (pair.animal2 == newAnimal && vacuumedAnimals.Contains(pair.animal1)))
            {
                CombineAnimals(pair.animal1, pair.animal2);

                // Remove the combined animals from the list
                vacuumedAnimals.Remove(pair.animal1);
                vacuumedAnimals.Remove(pair.animal2);

                break;
            }
        }
    }

    public void CombineAnimals(string animal1, string animal2)
    {
        Debug.Log($"Combined {animal1} and {animal2}!");
        Vector3 vacuumZoneCenter = GetComponent<Collider2D>().bounds.center;
        if ( (animal1 == "Pig" && animal2 == "Cloud") ||
            (animal1 == "Cloud" && animal2 == "Pig"))
        {
            string prefabPath = "Prefab/" + "cloudPig"; 
            GameObject combinedAnimalPrefab = Resources.Load<GameObject>(prefabPath);
            if (combinedAnimalPrefab != null)
            {
                GameObject combinedAnimal = Instantiate(combinedAnimalPrefab, vacuumZoneCenter, Quaternion.identity);
                Debug.Log("Cloudpig is here!!");
            }

        }

    }
}
