using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public Camera Camera;
    public Vector2 Sensitivity = new(1f, 1f);
    private Vector2 _orientation;
    private bool _startFlag;

    private void Start()
    {
        _orientation = new(transform.rotation.eulerAngles.y, 0f);
    }

    public void Look(Vector2 lookDelta)
    {
        if (!_startFlag) { _startFlag = true; return; }
        _orientation += lookDelta * Sensitivity;
        _orientation.y = Mathf.Clamp(_orientation.y, -90f, 90f);
        if (_orientation.x >= float.MaxValue || _orientation.x <= float.MinValue) _orientation.x = 0f;
        Camera.transform.localRotation = Quaternion.Euler(-_orientation.y, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, _orientation.x, 0f);
    }
}
