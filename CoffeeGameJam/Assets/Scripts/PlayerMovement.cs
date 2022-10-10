using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
    2D player movement script
    contains method of animations
    date: October 6th 2022
    */
    public Animator anim;
    private float moveInput;
    private float speed = 8f;
    private float jumpforce = 4f;
    private bool isFacingRight = false;

    //can do actions variables bools
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //jump variabales
    private bool canJump;
    private bool isJumping;
    private float jumpTimecounter;
    public float jumpTime;

    //dash variables
    private bool isDashing;
    private bool canDash;
    private float dashCooldown;
    private float dashingTime;
    private float dashingPower;

    //trail renderer && partical generations
    //add collisions


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //get horizontal input
        moveInput = Input.GetAxisRaw("Horizontal");
        //make character face the right way
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        ManageAnimations();

        Jump();
    }
    private void FixedUpdate()
    {

        Move();

    }

    private void Jump()
    {
        //needs to make fall time faster too slow 
        //spacebar functionality not working correctly
        //should hold down space to jump higher might remove later

        //check if feet touch the ground and space button is pressed
        if (IsGrounded() == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimecounter = jumpTime;
            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimecounter > 0)
            {
                rb.velocity = Vector2.up * jumpforce;
                jumpTimecounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void ManageAnimations()
    {
        if (IsGrounded() == false)
        {
            //play jump
            anim.SetBool("isJumping", true);
        }
        else if (moveInput == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", false);
        }
        else if (isDashing == true)
        {
            anim.SetBool("isDashing", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", true);
        }

    }
    private void Dash()
    {
        //if can dash is true






    }
    private void Move()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    //Player Collisions + stealing candy
    void OnTriggerEnter2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(col + "git");
           // col.GetComponent<NPC>().isMad = true;
        }
    }
}

