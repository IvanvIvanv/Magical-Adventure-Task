using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaver : MonoBehaviourID
{
    public EnemyDataInjector EnemyDataInjector;
    public EnemyHealth EnemyHealth;

    private EnemyJsonData _jsonData;

    private void Start()
    {
        EnemyHealth.HealthNoFlash = EnemyDataInjector.EnemyData.Health;

        if (!JsonSaverLib.Load<EnemyJsonData>(ID, out var loadedObject)) return;
        _jsonData = loadedObject;

        transform.SetPositionAndRotation(_jsonData.Position, _jsonData.Rotation);
        EnemyHealth.HealthNoFlash = _jsonData.Health;
    }

    private void OnDestroy() => Save();

    private void OnApplicationQuit() => Save();

    private void Save()
    {
        _jsonData ??= new();

        _jsonData.Position = transform.position;
        _jsonData.Rotation = transform.rotation;
        _jsonData.Health = EnemyHealth.Health;

        JsonSaverLib.Save(_jsonData, ID);
    }
}
