using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    private bool _isJumping;
    private bool _isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask whatIsGround;
    private float _jumpTimeCounter;
    [SerializeField] private float jumpTime;
    
    private Rigidbody _rb;
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rb.velocity = Vector3.up * jumpHeight;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (_jumpTimeCounter > 0 && _isJumping)
            {
                _rb.velocity = Vector3.up * jumpHeight;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false; 
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumping = false;
        }
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector3(speed * move, _rb.velocity.y, 0);

        
        //Rotate player
        if (move > 0)
        {
            transform.localScale = new Vector3(0.9f, 1.2f, 0.9f);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-0.9f, 1.2f, 0.9f);
        }
       
    }
    
}