using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private CharacterController _controller;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward *vertical;

        if (move.magnitude >= 0.1f)
            _controller.Move(move * _speed * Time.deltaTime);
    }
}
