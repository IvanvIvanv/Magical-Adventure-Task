using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;
    private Rigidbody _rb;
    private GroundedChecker _groundedChecker;

    private void Start()
    {
        _groundedChecker = GetComponent<GroundedChecker>();
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 inputDirection)
    {
        if (_groundedChecker != null && !_groundedChecker.IsGrounded) return;
        Vector3 moveDirection = inputDirection.InputDirectionToWorldDirection();
        _rb.AddForce(transform.rotation * moveDirection * Speed, ForceMode.Impulse);
    }

    public void Move(Vector3 targetPosition)
    {
        if (_groundedChecker != null && !_groundedChecker.IsGrounded) return;
        _rb.AddForce(Vector3.Normalize(targetPosition - transform.position) * Speed, ForceMode.Impulse);
    }
}
