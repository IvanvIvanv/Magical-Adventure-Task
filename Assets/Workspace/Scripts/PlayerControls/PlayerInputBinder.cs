using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerJump), typeof(PlayerLook))]
public class PlayerInputBinder : MonoBehaviour
{
    public InputContainer InputContainer;
    public InteractorCrosshair InteractorCrosshair;
    private PlayerMovement _playerMovement;
    private PlayerJump _playerJump;
    private PlayerLook _playerLook;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerJump = GetComponent<PlayerJump>();
        _playerLook = GetComponent<PlayerLook>();
        InputContainer.InputAsset.Player.Jump.started += OnJump;
        InputContainer.InputAsset.Player.Look.started += OnLook;
        InputContainer.InputAsset.Player.Interact.started += OnInteract;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var moveDirection = InputContainer.InputAsset.Player.Move.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _playerJump.Jump();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        _playerLook.Look(context.ReadValue<Vector2>());
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        InteractorCrosshair.Interact();
    }
}
