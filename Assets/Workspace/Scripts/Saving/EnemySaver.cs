using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaver : MonoBehaviour
{
    public EnemyHealth EnemyHealth;

    private EnemyJsonData _jsonData;

    private void Start()
    {
        if (!JsonSaverLib.Load<EnemyJsonData>(GetHashCode(), out var loadedObject)) return;
        _jsonData = loadedObject;

        transform.SetPositionAndRotation(_jsonData.Position, _jsonData.Rotation);
        EnemyHealth.Health = _jsonData.Health;
    }

    private void OnApplicationQuit()
    {
        _jsonData ??= new();

        _jsonData.Position = transform.position;
        _jsonData.Rotation = transform.rotation;
        _jsonData.Health = EnemyHealth.Health;

        JsonSaverLib.Save(_jsonData, GetHashCode());
    }
}
