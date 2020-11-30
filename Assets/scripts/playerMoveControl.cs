﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveControl : MonoBehaviour
{
    public myCharCont controller;
    // // public Animator animator;
    public Joystick joystick;

    public float swingForce = 4f;
    public float speed = 40f;
    public Vector2 ropeHook;
    public bool isSwinging;
    public bool groundCheck;
    private SpriteRenderer playerSprite;
    private Rigidbody2D rBody;
    bool IsJumping = false;
    // private Animator animator;
    // private float jumpInput;
    float horizontalMove = 0f;

    // Rope system variables
    

    void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal >= .2f){
            horizontalMove = speed;
        } else if (joystick.Horizontal <= -.2f){
            horizontalMove = -speed;
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
        //     Debug.Log("swing man swing man SWING MAN");
        // }
    }

    // public void OnLanding ()
    // {
    //     //Move our character
    //     // animator.SetBool("IsJumping", false);
    // }

    void FixedUpdate()
    {
        // if (joystick.Vertical < -0.5f)
        // {
        //     // animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        //     // playerSprite.flipX = horizontalInput < 0f;
        //     if (isSwinging)
        //     {
        //         // animator.SetBool("IsSwinging", true);

        //         // 1 - Get a normalized direction vector from the player to the hook point
        //         var playerToHookDirection = (ropeHook - (Vector2)transform.position).normalized;

        //         // 2 - Inverse the direction to get a perpendicular direction
        //         Vector2 perpendicularDirection;
        //         if (horizontalMove < 0)
        //         {
        //             perpendicularDirection = new Vector2(-playerToHookDirection.y, playerToHookDirection.x);
        //             var leftPerpPos = (Vector2)transform.position - perpendicularDirection * -2f;
        //             Debug.DrawLine(transform.position, leftPerpPos, Color.green, 0f);
        //         }
        //         else
        //         {
        //             perpendicularDirection = new Vector2(playerToHookDirection.y, -playerToHookDirection.x);
        //             var rightPerpPos = (Vector2)transform.position + perpendicularDirection * 2f;
        //             Debug.DrawLine(transform.position, rightPerpPos, Color.green, 0f);
        //         }

        //         var force = perpendicularDirection * swingForce;
        //         rBody.AddForce(force, ForceMode2D.Force);
        //     }
        //     else
        //     {
        //         // animator.SetBool("IsSwinging", false);
        //         if (groundCheck)
        //         {
        //             var groundForce = speed * 2f;
        //             rBody.AddForce(new Vector2((horizontalMove * groundForce - rBody.velocity.x) * groundForce, 0));
        //             rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y);
        //         }
        //     }
        // }
        // else
        // {
        //     animator.SetBool("IsSwinging", false);
        //     animator.SetFloat("Speed", 0f);
        // }

        // if (!isSwinging)
        // {
        //     if (!groundCheck) return;

        //     IsJumping = jumpInput > 0f;
        //     if (IsJumping)
        //     {
        //         rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
        //     }
        // }
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, IsJumping);
        IsJumping = false;
    }

    //GrappleObject is a function that will be used in a button componenet to grapple
    public void GrappleObject()
    {
            if (isSwinging)
            {
                // animator.SetBool("IsSwinging", true);

                // 1 - Get a normalized direction vector from the player to the hook point
                var playerToHookDirection = (ropeHook - (Vector2)transform.position).normalized;

                // 2 - Inverse the direction to get a perpendicular direction
                Vector2 perpendicularDirection;
                if (horizontalMove < 0)
                {
                    perpendicularDirection = new Vector2(-playerToHookDirection.y, playerToHookDirection.x);
                    var leftPerpPos = (Vector2)transform.position - perpendicularDirection * -2f;
                    Debug.DrawLine(transform.position, leftPerpPos, Color.green, 0f);
                }
                else
                {
                    perpendicularDirection = new Vector2(playerToHookDirection.y, -playerToHookDirection.x);
                    var rightPerpPos = (Vector2)transform.position + perpendicularDirection * 2f;
                    Debug.DrawLine(transform.position, rightPerpPos, Color.green, 0f);
                }

                var force = perpendicularDirection * swingForce;
                rBody.AddForce(force, ForceMode2D.Force);
            }
            else
            {
                // animator.SetBool("IsSwinging", false);
                if (groundCheck)
                {
                    var groundForce = speed * 2f;
                    rBody.AddForce(new Vector2((horizontalMove * groundForce - rBody.velocity.x) * groundForce, 0));
                    rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y);
                }
            }
        }
}
