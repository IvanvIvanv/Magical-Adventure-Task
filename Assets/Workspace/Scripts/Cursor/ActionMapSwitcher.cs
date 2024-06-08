using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionMapSwitcher : MonoBehaviour
{
    public InputContainer InputContainer;
    private bool _isPlayer = true;

    private void Start()
    {
        InputContainer.InputAsset.ActionMapSwitcher.SwitchActionMap.Enable();
        SwitchMap();
        InputContainer.InputAsset.ActionMapSwitcher.SwitchActionMap.started += OnMapSwitched;
    }

    private void OnMapSwitched(InputAction.CallbackContext context)
    {
        _isPlayer = !_isPlayer;
        SwitchMap();
    }

    private void SwitchMap() 
    {
        if (_isPlayer)
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
