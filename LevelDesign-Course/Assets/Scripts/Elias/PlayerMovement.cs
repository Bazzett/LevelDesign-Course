using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [Header("Movement values")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpHeight = 3f;
    
    [Header("Gravity")]
    [SerializeField] private float gravity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    
    private Vector3 _velocity;
    private bool _isGrounded;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //Check if the player are touching the ground
        // Check from the feet and a little before 
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        Jump();
        Movement();
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
        
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            /*float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle,0f);*/
            
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
