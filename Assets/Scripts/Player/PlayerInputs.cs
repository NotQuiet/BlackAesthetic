using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;

    // input fields
    private InputMaster _playerActionsAsset;
    private InputAction _move;

    // movement fields
    private Rigidbody _rigidbody;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Camera _playerThirdPersonCamera;

    private Vector3 _forceDirection = Vector3.zero;

    [SerializeField] private float _maxSpeed; // im think that is not what actualy needed

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerActionsAsset = new InputMaster();
    }

    private void OnEnable()
    {
        _playerActionsAsset.Player.Jump.started += DoJump;
        _move = _playerActionsAsset.Player.Move;
        _playerActionsAsset.Player.Enable();
    }

    private void OnDisable()
    {
        _playerActionsAsset.Player.Jump.started -= DoJump;
        _playerActionsAsset.Player.Disable();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _forceDirection += _move.ReadValue<Vector2>().x * GetCameraRight(_playerThirdPersonCamera) * _movementSpeed;
        _forceDirection += _move.ReadValue<Vector2>().y * GetCameraForward(_playerThirdPersonCamera) * _movementSpeed;

        _rigidbody.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
        {
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.deltaTime;
        }

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0f;
        if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
        {
            _rigidbody.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rigidbody.velocity.y;
        }

        SetLookingDirection();
    }

    private void SetLookingDirection()
    {
        Vector3 lookingDirection = _rigidbody.velocity;
        lookingDirection.y = 0f;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && lookingDirection.sqrMagnitude > 0.1f)
            this._rigidbody.rotation = Quaternion.LookRotation(lookingDirection, Vector3.up);
        else
            this._rigidbody.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerThirdPersonCamera)
    {
        Vector3 forward = playerThirdPersonCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerThirdPersonCamera)
    {
        Vector3 right = playerThirdPersonCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("IsGrounded(): " + IsGrounded());

        if(IsGrounded())
        {
            _forceDirection += Vector3.up * _jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.25f, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f, groundLayers))
            return true;
        else
            return false;
    }








    #region Another input version

    //[SerializeField] private float moveSpeed;

    //private bool _isOnGround = true;
    //private bool _isDefaultEli = true;

    //private Vector2 m_Move;

    //private void Update()
    //{
    //    Move(m_Move);
    //}

    //private void Move(Vector2 direction)
    //{
    //    if (direction.sqrMagnitude < 0.01)
    //        return;

    //    var scaledMoveSpeed = moveSpeed * Time.deltaTime;

    //    var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) *
    //        new Vector3(direction.x, 0, direction.y);

    //    transform.position += move * scaledMoveSpeed;
    //}

    //private void Jump()
    //{
    //    Debug.Log("Jump");
    //}

    #region InputSystem callbacks

    //public void OnJump(InputAction.CallbackContext context)
    //{
    //    switch (context.phase)
    //    {
    //        case InputActionPhase.Performed:
    //            if(_isOnGround && _isDefaultEli)
    //            {
    //                Jump();
    //            }
    //            break;
    //    }
    //}

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    m_Move = context.ReadValue<Vector2>();
    //}

    #endregion

    #endregion
}
