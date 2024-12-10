using UnityEngine;

public class PrefabLoader : MonoBehaviour
{
    public GameObject prefab; // Drag your prefab here in the Inspector
    private static bool isLoaded = false;

    private void Awake()
    {
        if (!isLoaded)
        {
            LoadPrefab();
            isLoaded = true; // Mark the prefab as loaded
        } 
    }

    void LoadPrefab()
    {
        if (prefab != null)
        {
            // Instantiate the prefab in the scene
            GameObject instance = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            instance.name = "MyPrefabInstance"; // Optional: Rename the instantiated prefab
            DontDestroyOnLoad(instance);
        }
        else
        {
            Debug.LogError("Prefab not assigned in the Inspector!");
        }
    }
}
