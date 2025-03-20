using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class autoBacktoTitle : MonoBehaviour
{

    private float step_time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {
            step_time += Time.deltaTime;
        }
        else
        {
            step_time = 0;
        }
        if(step_time > 10f)
        {
            GameObject ufoObject = GameObject.Find("MyPrefabInstance");
            if (ufoObject != null)
            {
                Destroy(ufoObject);
                PrefabLoader.isLoaded = false;
            }
            SceneManager.LoadScene(0);
        }
    }
}
