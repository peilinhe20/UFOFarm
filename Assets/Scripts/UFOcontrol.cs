using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UFOcontrol : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Awake() {
        //DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);
        if(transform.position.x <= -7)
        {
            transform.position = new Vector3(-7, transform.position.y, 0);
        }
        else if (transform.position.x >= 7)
        {
            transform.position = new Vector3(7, transform.position.y, 0);
        }

        if (transform.position.y <= -3)
        {
            transform.position = new Vector3(transform.position.x, -3, 0);
        }
        else if (transform.position.y >= 3)
        {
            transform.position = new Vector3(transform.position.x, 3, 0);
        }
    }
}
