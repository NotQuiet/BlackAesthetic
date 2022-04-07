using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliAnimationController : MonoBehaviour
{
    [SerializeField] private LayerMask m_LayerMask;

    private Animator _animator;

    void Awake() => _animator = GetComponent<Animator>();

    public void EliWalkAnimated(Vector3 movement)
    {
        float velosityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velosityX = Vector3.Dot(movement.normalized, transform.right);

        _animator.SetFloat("VelocityZ", velosityZ, 0.1f, Time.deltaTime);
        _animator.SetFloat("VelocityX", velosityX, 0.1f, Time.deltaTime);
    }

    private void Update()
    {
        Vector3 vector3 = new Vector3(transform.position.x, 0f, transform.position.z);

        EliWalkAnimated(transform.forward);   
    }
}
