using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputMaster controls;

    private void Awake()
    {
        controls.Player.Jump.performed += contex => OnJump();
    }

    private void OnJump()
    {
        Debug.Log("Jump");
    }
}
