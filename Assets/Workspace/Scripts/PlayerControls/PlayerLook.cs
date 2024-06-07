using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public Camera Camera;
    public InputContainer InputContainer;
    private InputAction _lookAction;
    private Vector2 _desiredLook;

    private void Start()
    {
        _desiredLook = new(transform.rotation.eulerAngles.x, 0f);
        _lookAction = InputContainer.InputAsset.Player.Look;
        _lookAction.started += OnLook;
    }

    private void Update()
    {
        Vector2 lerpLook = Vector2.Lerp(_desiredLook, new(transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.x), Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, lerpLook.x, 0f);
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        var lookDelta = context.ReadValue<Vector2>();
        _desiredLook += lookDelta;
    }
}
