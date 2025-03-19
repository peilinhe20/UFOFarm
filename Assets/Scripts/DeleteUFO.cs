using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUFO : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject ufoObject = GameObject.Find("MyPrefabInstance");
        if(ufoObject != null )
        {
            Destroy( ufoObject );
            PrefabLoader.isLoaded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
