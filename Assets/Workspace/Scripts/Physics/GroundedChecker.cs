using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
    public float Radius = 1f;
    public float MaxDistance = 1f;
    public bool DrawGizmo;

    public bool IsGrounded
    {
        get
        {
            return CastToGround(out var hitInfo) && hitInfo.distance < MaxDistance;
        }
    }

    private void OnDrawGizmos()
    {
        if (!DrawGizmo) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);
        if (!CastToGround(out var hitInfo)) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(hitInfo.point, Radius);
    }

    private bool CastToGround()
    {
        return Physics.SphereCast(transform.position, Radius, Vector3.down, out _);
    }

    private bool CastToGround(out RaycastHit hitInfo)
    {
        return Physics.SphereCast(transform.position, Radius, Vector3.down, out hitInfo);
    }
}
