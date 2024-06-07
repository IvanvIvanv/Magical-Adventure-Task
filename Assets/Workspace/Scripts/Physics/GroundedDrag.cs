using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundedChecker), typeof(DragVector3))]
public class GroundedDrag : MonoBehaviour
{
    public Vector3 DragWhileGrounded;
    private GroundedChecker _groundChecker;
    private DragVector3 _dragVector3;

    private void Start()
    {
        _groundChecker = GetComponent<GroundedChecker>();
        _dragVector3 = GetComponent<DragVector3>();
    }

    private void FixedUpdate()
    {
        if (_groundChecker.IsGrounded)
            _dragVector3.Drag = DragWhileGrounded;
        else
            _dragVector3.ResetDrag();
    }
}
