using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;

        if (keyboard == null && mouse == null)
            return;

        if (keyboard.spaceKey.wasPressedThisFrame)
            Jump();
    }

    private void Jump()
    {
        Debug.Log("Jump");
    }
    

}
