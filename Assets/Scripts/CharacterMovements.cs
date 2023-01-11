using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private CharacterController _controller;
    private float _minVectorLength = 0.1f;

    private void Start() => _controller = GetComponent<CharacterController>();

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward *vertical;

        if (move.magnitude >= _minVectorLength)
            _controller.Move(move * _speed * Time.deltaTime);
    }
}
