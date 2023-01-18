using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float _mouseSencitivity;
    [SerializeField] Transform _playerBody;
    
    float _xRotation;
    float _yRotation;

    private void Start() 
    {
        HideCursore();
    }

    void Update()
    {
        CameraMovement();
    }

    private void HideCursore()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSencitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSencitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
