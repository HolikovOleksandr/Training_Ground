using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    private bool _grounded;

    public Transform orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        // Ground check
        _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); 

        MyInput(); 
        // SpeedControl();

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
    }

    private void MovePlayer()
    {
        // Calculate movment direction
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

        _rb.AddForce(_moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelosity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        // Limit velosity if need
        if(flatVelosity.magnitude > moveSpeed)
        {
            Vector3 limitedVelosity = flatVelosity.normalized * moveSpeed;
            _rb.velocity = new Vector3(limitedVelosity.x, _rb.velocity.y, limitedVelosity.x);
        }
    }
}
