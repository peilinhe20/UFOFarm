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
        GameObject Ctrl = GameObject.Find("Serial_test");
        if (Ctrl != null)
        {
            SerialReceive Recieve = Ctrl.GetComponent<SerialReceive>();
            if (!Input.anyKey && Recieve.SerialX == 0 && Recieve.SerialY == 0 && Recieve.Enter == 0)
            {
                step_time += Time.deltaTime;
            }
            else
            {
                step_time = 0;
            }
            if (step_time > 60f)
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
        else
        {
            if (!Input.anyKey)
            {
                step_time += Time.deltaTime;
            }
            else
            {
                step_time = 0;
            }
            if (step_time > 60f)
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


}
