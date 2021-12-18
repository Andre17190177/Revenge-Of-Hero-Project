using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        //Gget Inputs
        moveDirection = Input.GetAxis("Horizontal"); 

        // Jump
  
        
        // move
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

}