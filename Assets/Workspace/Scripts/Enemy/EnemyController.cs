using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SpottingRadius SpottingRadius;
    public PlayerMovement PlayerMovement;

    private void FixedUpdate()
    {
        if (SpottingRadius.TransformTargets.Count == 0) return;
        Transform closest = GetClosestEnemy(SpottingRadius.TransformTargets.ToArray());
        PlayerMovement.Move(closest.position);
    }

    Transform GetClosestEnemy(Transform[] enemies)
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
