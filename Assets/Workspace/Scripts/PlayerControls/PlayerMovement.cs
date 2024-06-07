using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public InputContainer InputContainer;
    public float Speed = 1f;
    private Rigidbody _rb;
    private GroundedChecker _groundedChecker;
    private InputAction _moveAction;

    private void Start()
    {
        _groundedChecker = GetComponent<GroundedChecker>();
        _rb = GetComponent<Rigidbody>();
        _moveAction = InputContainer.InputAsset.Player.Move;
    }

    private void FixedUpdate()
    {
        if (_groundedChecker != null && !_groundedChecker.IsGrounded) return;
        var inputDirection = _moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = inputDirection.InputDirectionToWorldDirection();
        _rb.AddForce(transform.rotation * moveDirection * Speed, ForceMode.Impulse);
    }
}
