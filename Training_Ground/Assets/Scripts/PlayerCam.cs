using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform orientation;

    public float sensX;
    public float sensY;

    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get muse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f,  90f);

        // Rotate cam and orientation
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }

}
