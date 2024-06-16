using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBinder : MonoBehaviour, IEnemyTarget
{
    public InputContainer InputContainer;
    public InteractorCrosshair InteractorCrosshair;
    public Hotbar Hotbar;
    private PlayerMovement _playerMovement;
    private PlayerJump _playerJump;
    private PlayerLook _playerLook;
    private PlayerInventory _playerInventory;
    private PlayerAttack _playerAttack;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerJump = GetComponent<PlayerJump>();
        _playerLook = GetComponent<PlayerLook>();
        _playerInventory = GetComponent<PlayerInventory>();
        _playerAttack = GetComponent<PlayerAttack>();
        InputContainer.InputAsset.Player.Jump.started += OnJump;
        InputContainer.InputAsset.Player.Look.started += OnLook;
        InputContainer.InputAsset.Player.Interact.started += OnInteract;
        InputContainer.InputAsset.Player.Inventory.started += OnInventory;
        InputContainer.InputAsset.Player.ScrollHotbar.started += OnScrollHotbar;
        InputContainer.InputAsset.Player.Attack.started += OnPlayerAttack;
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

    private void OnInventory(InputAction.CallbackContext context)
    {
        _playerInventory.ToggleInventory();
    }

    private void OnScrollHotbar(InputAction.CallbackContext context)
    {
        float scrollDir = context.ReadValue<Vector2>().y;
        if (scrollDir > 0) Hotbar.Selected--;
        else Hotbar.Selected++;
    }

    private void OnPlayerAttack(InputAction.CallbackContext context)
    {
        _playerAttack.Attack();
    }
}
