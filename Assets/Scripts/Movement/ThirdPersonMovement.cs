using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _cam;
    [SerializeField] private Transform _groundCheck;

    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _runMultiply = 1.5f;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    [SerializeField] private float _jumpHight = 2f;

    private Vector3 _velocity;

    private float _gravity = -9.81f;
    private float _turnSmoothVelocity;
    private float _startSpeed;
    private float _groundDistance = 0.1f;
    private bool _isGrounded;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _startSpeed = _speed;
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed *= _runMultiply;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _startSpeed;
        }

        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHight * -2 * _gravity);
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(moveDirection.normalized * _speed * Time.deltaTime);
        }

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        else
        {
            _velocity.y += _gravity * 2 * Time.deltaTime;

            _controller.Move(_velocity * Time.deltaTime);
        }
        
    }
}
