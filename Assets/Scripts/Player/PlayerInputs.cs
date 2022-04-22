using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private bool _isOnGround = true;
    private bool _isDefaultEli = true;

    private Vector3 m_Move;

    private void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;

        if (keyboard == null && mouse == null)
            return;



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
        m_Move = context.ReadValue<Vector3>();
    }

    #endregion



}
