using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottingRadius : MonoBehaviour
{
    [System.NonSerialized] public List<Transform> TransformTargets = new();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IEnemyTarget>(out _)) return;
        TransformTargets.Add(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<IEnemyTarget>(out _)) return;
        TransformTargets.Remove(other.transform);
    }
}
