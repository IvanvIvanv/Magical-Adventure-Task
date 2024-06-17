using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SpottingRadius SpottingRadius;
    public PlayerMovement PlayerMovement;

    public Transform ClosestTarget
    {
        get
        {
            if (SpottingRadius.TransformTargets.Count == 0) return null;
            return GetClosestEnemy(SpottingRadius.TransformTargets.ToArray());
        }
    }

    private void FixedUpdate()
    {
        if (ClosestTarget == null) return;
        PlayerMovement.Move(ClosestTarget.position);
        transform.LookAt(ClosestTarget.position);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    public Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
