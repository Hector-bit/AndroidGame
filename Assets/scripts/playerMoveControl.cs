using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveControl : MonoBehaviour
{
    public myCharCont controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    public bool isSwinging;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate ()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}