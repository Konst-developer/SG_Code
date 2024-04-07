using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField] private Tube1 tube1;
    [SerializeField] private Tube2 tube2;
    [SerializeField] private Tube3 tube3;
    [SerializeField] private Tube4 tube4;
    float speed = 2f;
    private Vector3 lastMouse = new Vector3(255, 255, 0);
    float camSens = 0.25f;
    float playerSize = 0.5f;
    bool canMove;
    Vector3 dr = new Vector3(0, 0, 0);
    float lastPress = 0f;
    

    void Start()
    {
        dr = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(0, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(0, transform.eulerAngles.y + lastMouse.y, 0);
        //Debug.Log(lastMouse.y);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        Vector3 move = getControls() * speed * Time.deltaTime;
        transform.Translate(move);

        canMove = !Physics.Raycast(transform.position, /*transform.TransformDirection(Vector3.forward)*/transform.position - dr, playerSize); ;
            

        if (canMove)
        {
            dr = transform.position;
        }
        else 
            transform.position = dr;
        checkEnter();
    }

    Vector3 getControls()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
            dir += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.S))
            dir += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.A))
            dir += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.D))
            dir += new Vector3(1, 0, 0);
        return dir.normalized;
    }

    void checkEnter()
    {
        //Debug.Log(gobj.getColor());
         
        if (Input.GetKey(KeyCode.Space)&&Time.time-lastPress>0.25)
        {
            Vector2 curPos = new Vector2(transform.position.x, transform.position.z);
            Vector2 distT = tube1.getPosition()-curPos;
            if (distT.magnitude <= 0.8) tube1.nextColor();
            distT = tube2.getPosition() - curPos;
            if (distT.magnitude <= 0.8) tube2.nextColor();
            distT = tube3.getPosition() - curPos;
            if (distT.magnitude <= 0.8) tube3.nextColor();
            distT = tube4.getPosition() - curPos;
            if (distT.magnitude <= 0.8) tube4.nextColor();

            lastPress=Time.time;
            //Debug.Log(distT1.magnitude);
        }
    }
}
