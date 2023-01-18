using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _controller;
    Vector3 _velosity;

    [SerializeField] float _speed;
    [SerializeField] float _jumpHeight;
    [SerializeField] KeyCode _jumpKey;

    [SerializeField] short _gravityScale;
    float _gravity = -9.81f;

    [SerializeField] LayerMask _layerMask;
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundDistance;
    bool _isGrounded;

    


    private void Start()
    {
        _controller = GetComponent<CharacterController>();    
    }

    private void Update() 
    {
        CharacterMovement();
        GroundCheck();
        Jump();
    }

    private void CharacterMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _speed * Time.deltaTime);

        _velosity.y += _gravity * _gravityScale * Time.deltaTime;
        _controller.Move(_velosity * Time.deltaTime);

    }

    private void GroundCheck()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _layerMask);
        if(_isGrounded && _velosity.y < 0) _velosity.y = -2f;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(_jumpKey) && _isGrounded)
        {
            _velosity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity * _gravityScale);
        }
    }

}
