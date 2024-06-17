using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaver : MonoBehaviour
{
    public EnemyDataInjector EnemyDataInjector;
    public EnemyHealth EnemyHealth;

    private EnemyJsonData _jsonData;

    private void Start()
    {
        EnemyHealth.Health = EnemyDataInjector.EnemyData.Health;

        if (!JsonSaverLib.Load<EnemyJsonData>(GetHashCode(), out var loadedObject)) return;
        _jsonData = loadedObject;

        transform.SetPositionAndRotation(_jsonData.Position, _jsonData.Rotation);
        EnemyHealth.Health = _jsonData.Health;
    }

    private void OnDestroy() => Save();

    private void OnApplicationQuit() => Save();

    private void Save()
    {
        _jsonData ??= new();

        _jsonData.Position = transform.position;
        _jsonData.Rotation = transform.rotation;
        _jsonData.Health = EnemyHealth.Health;

        JsonSaverLib.Save(_jsonData, GetHashCode());
    }
}
