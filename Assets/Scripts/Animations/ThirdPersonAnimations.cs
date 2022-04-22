using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimations : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    private float _maxSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _rb.velocity.sqrMagnitude / _maxSpeed);
    }
}
