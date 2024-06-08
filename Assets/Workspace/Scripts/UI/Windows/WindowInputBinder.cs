using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowInputBinder : MonoBehaviour
{
    public InputContainer InputContainer;
    public Vector2 MouseDelta { get; private set; }

    private void Start()
    {
        InputContainer.InputAsset.UI.MouseDelta.started += OnMouseDelta;
    }

    private void OnMouseDelta(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }
}
