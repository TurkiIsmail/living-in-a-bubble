using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermouvement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float slowspeed = 24f;
    Vector3 veclocity;
    public float gravity = -9.81f;
    //public Transform groundcheck;
    public float groundistance = 0.4f;
    public LayerMask groundmask;
    bool isgrounded;
    public float jumpheight = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //isgrounded = Physics.CheckSphere(groundcheck.position, groundistance, groundmask);
        
        if(veclocity.y < 0)
        {
            veclocity.y = -2f;
        }
            
            


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * slowspeed * Time.deltaTime);
        }


        if(Input.GetButtonDown("Jump") && isgrounded)
        {
            veclocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        veclocity.y += gravity * Time.deltaTime;

        controller.Move(veclocity * Time.deltaTime);
    }
}
