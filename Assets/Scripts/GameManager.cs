using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int totalScenes;

    protected override void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
        totalScenes = SceneManager.sceneCountInBuildSettings;
    }

    public void LoadNextScene () {
        int index = SceneManager.GetActiveScene().buildIndex;

        if(index + 1 < totalScenes) {
            SceneManager.LoadScene(index + 1);
        }
        else{
            //quit the game or ???
        }        
    }

    public void LoadLastScene () {
        int index = SceneManager.GetActiveScene().buildIndex;

        if(index - 1 >= 0) {
            SceneManager.LoadScene(index - 1);
        }
        else{
            //quit the game or ???
        }        
    }

    public void LoadFirstScene () {
        GameObject ufoObject = GameObject.Find("MyPrefabInstance");
        if (ufoObject != null)
        {
            Destroy(ufoObject);
            PrefabLoader.isLoaded = false;
        }
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Additional logic can be added here if needed when a scene is loaded
    }

    private void CheatKeyToNextScene() {
        if(Input.GetKeyDown(KeyCode.K)) {
            LoadNextScene();
        }
    }
}