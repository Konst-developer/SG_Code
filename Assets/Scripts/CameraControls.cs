using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private Vector3 lastMouse = new Vector3(255, 0, 255);
    float camSens = 0.25f;
    //float speed = 2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, 0, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;

    }

}
