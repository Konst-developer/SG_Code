using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    bool isMoving = false;
    float moveSpeed = 0.03f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, moveSpeed*Time.deltaTime, 0);
        if (isMoving)
            transform.Translate(move);
       
    }

    public void startMove()
    {
        isMoving = true;
    }
}
