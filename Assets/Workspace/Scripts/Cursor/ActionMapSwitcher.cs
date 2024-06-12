using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ActionMapSwitcher : MonoBehaviour
{
    public InputContainer InputContainer;
    private bool IsPlayer = true;
    public readonly UnityEvent<bool> OnControlModeSwitched = new();

    private void Start()
    {
        InputContainer.InputAsset.ActionMapSwitcher.SwitchActionMap.Enable();
        SwitchMap();
        InputContainer.InputAsset.ActionMapSwitcher.SwitchActionMap.started += OnMapSwitched;
    }

    private void OnMapSwitched(InputAction.CallbackContext context)
    {
        IsPlayer = !IsPlayer;
        SwitchMap();
        OnControlModeSwitched.Invoke(IsPlayer);
    }

    private void SwitchMap() 
    {
        if (IsPlayer)
        {
            InputContainer.InputAsset.Player.Enable();
            InputContainer.InputAsset.UI.Disable();
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            InputContainer.InputAsset.Player.Disable();
            InputContainer.InputAsset.UI.Enable();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
