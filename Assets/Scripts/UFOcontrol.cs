using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOcontrol : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);
    }
}
