using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControll : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Joystick joystick;
    public Animator animator;
    public Button attackButton;
    float horizontalMove = 0f;
    bool jump;

    [Header("Dash")]
    public float dashSpeed;
    public float dashLength = 2f;
    public float dashCooldown = 1f;
    private float activeMoveSpeed;
    private float dashCounter;
    private float dashCoolCounter;

    private void Awake()
    {
        activeMoveSpeed = runSpeed;
    }

    // Update is called once per frame
    public void Update()
    {
        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = activeMoveSpeed;
        }
        else if(joystick.Horizontal <= -.2f)
        {
            horizontalMove = -activeMoveSpeed;
        }
        else
        {
            animator.SetBool("isDashing", false);
            horizontalMove = 0f;
        }

        float verticalMove = joystick.Vertical;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (verticalMove >= .8f)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            attackButton.interactable = false;
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                animator.SetBool("isDashing", false);
                activeMoveSpeed = runSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    public void Dashing()
    {
        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            animator.SetBool("isDashing", true);
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        attackButton.interactable = true;
    }

    private void FixedUpdate()
    {
        //Menggerakan Karakter
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
