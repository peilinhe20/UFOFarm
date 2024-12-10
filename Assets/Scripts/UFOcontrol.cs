using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOcontrol : MonoBehaviour
{
    public float moveSpeed = 5f;

    private GameObject Ctrl;
    SerialReceive Recieve;

    void Update()
    {
        Ctrl = GameObject.Find("Serial_test");
        Recieve = Ctrl.GetComponent<SerialReceive>();
        float moveX = Recieve.A;
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);
    }
}
