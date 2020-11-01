using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveControl : MonoBehaviour
{
    public myCharCont controller;
    // // public Animator animator;

    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    
    bool IsJumping = false;
    public bool isSwinging;

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal >= .2f){
            horizontalMove = runSpeed;
        } else if (joystick.Horizontal <= -.2f){
            horizontalMove = -runSpeed;
        } else {
            horizontalMove = 0f;
        }

        // animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        float verticalMove = joystick.Vertical;

        if(verticalMove >= .5f){
            IsJumping = true;
            // animator.SetBool("IsJumping", true);
        }

        // if(verticalMove <= -.5f){
        //     crouch = true;
        // } else {
        //     crouch = false;
        // }
    }

    public void OnLanding ()
    {
        //Move our character
        // animator.SetBool("IsJumping", false);
    }

    void FixedUpdate ()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, IsJumping);
        IsJumping = false;
    }
}