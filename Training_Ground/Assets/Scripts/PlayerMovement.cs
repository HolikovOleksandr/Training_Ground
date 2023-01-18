using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForse;
    public float jumpCooldown;
    public float airMultiplier;
    [SerializeField] private bool _readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    [SerializeField] private bool _grounded;

    public Transform orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _readyToJump = true;
    }

    private void Update()
    {
        // Ground check
        _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); 

        MyInput(); 

        // Handle drag
        if(_grounded) _rb.drag = groundDrag;
        else _rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();    
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        // When to jump
        if(Input.GetKey(jumpKey) && _readyToJump && _grounded)
        {
            _readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // Calculate movment direction
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

        // On ground
        if(_grounded)
            _rb.AddForce(_moveDirection.normalized * moveSpeed, ForceMode.Force);
        
        // In air
        // else if(!_grounded)
        //     _rb.AddForce(_moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 flatVelosity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        // Limit velosity if needed
        if(flatVelosity.magnitude > moveSpeed)
        {
            Vector3 limitedVelosity = flatVelosity.normalized * moveSpeed;
            _rb.velocity = new Vector3(limitedVelosity.x, _rb.velocity.y, limitedVelosity.z);
        }
    }

    private void Jump()
    {
        // Reset Y velosity
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        _rb.AddForce(transform.up * jumpForse, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        _readyToJump = true;
    }
}
