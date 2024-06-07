using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragVector3 : MonoBehaviour
{
    [SerializeField] private Vector3 _initialDrag;
    public Vector3 InitialDrag { get => _initialDrag; }
    [System.NonSerialized] public Vector3 Drag;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Drag = InitialDrag;
    }

    private void FixedUpdate()
    {
        ApplyDrag();
    }

    private void ApplyDrag()
    {
        _rb.velocity = Vector3.Scale(_rb.velocity, Drag.Add(1f).Invert());
    }

    public void ResetDrag()
    {
        Drag = InitialDrag;
    }
}