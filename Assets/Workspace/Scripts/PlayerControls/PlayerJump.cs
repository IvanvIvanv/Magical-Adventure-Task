using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    public float Force = 100f;
    private Rigidbody _rb;
    private GroundedChecker _groundedChecker;

    private void Start()
    {
        _groundedChecker = GetComponent<GroundedChecker>();
        _rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (_groundedChecker != null && !_groundedChecker.IsGrounded) return;
        _rb.AddForce(0f, Force, 0f, ForceMode.Impulse);
    }
}
