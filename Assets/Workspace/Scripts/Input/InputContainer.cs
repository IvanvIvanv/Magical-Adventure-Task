using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputContainer : MonoBehaviour
{
    private InputAsset _inputAsset;
    public InputAsset InputAsset 
    {
        get
        {
            _inputAsset ??= new();
            return _inputAsset;
        }
        private set => _inputAsset = value;
    }

    private void OnDisable()
    {
        InputAsset.Disable();
    }
}