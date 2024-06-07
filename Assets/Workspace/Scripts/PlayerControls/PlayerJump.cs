using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    public InputContainer InputContainer;
    public float Force = 100f;
    private Rigidbody _rb;
    private GroundedChecker _groundedChecker;
    private InputAction _jumpAction;

    private void Start()
    {
        _groundedChecker = GetComponent<GroundedChecker>();
        _rb = GetComponent<Rigidbody>();
        _jumpAction = InputContainer.InputAsset.Player.Jump;
        _jumpAction.started += OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundedChecker != null && !_groundedChecker.IsGrounded) return;
        _rb.AddForce(0f, Force, 0f, ForceMode.Impulse);
    }
}
