using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSaver : MonoBehaviourID
{
    public Inventory Inventory;

    private ChestJsonData _jsonData;

    private void Start()
    {
        if (!JsonSaverLib.Load<ChestJsonData>(ID, out var loadedObject)) return;
        _jsonData = loadedObject;

        Inventory.Items = _jsonData.Items;
    }

    private void OnApplicationQuit()
    {
        _jsonData ??= new();

        _jsonData.Items = Inventory.Items;

        JsonSaverLib.Save(_jsonData, ID);
    }
}
