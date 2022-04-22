using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private bool _isOnGround = true;
    private bool _isDefaultEli = true;

    private Vector2 m_Move;

    private void Update()
    {
        Move(m_Move);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;

        var scaledMoveSpeed = moveSpeed * Time.deltaTime;

        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) *
            new Vector3(direction.x, 0, direction.y);

        transform.position += move * scaledMoveSpeed;
    }

    private void Jump()
    {
        Debug.Log("Jump");
    }

    #region InputSystem callbacks

    public void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                if(_isOnGround && _isDefaultEli)
                {
                    Jump();
                }
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    #endregion



}
