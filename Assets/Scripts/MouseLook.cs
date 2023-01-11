using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSentivity = 500f;
    [SerializeField] private Transform _playerBody;

    private float _xRotation;
    private float _xRotationMax = 90f;
    private float _xRotationMin = -90f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _xRotation = 0f;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSentivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSentivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _xRotationMin, _xRotationMax);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
