using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    public Inventory Inventory;
    public Inventory Hotbar;
    public PlayerHealth PlayerHealth;

    private PlayerJsonData _playerJsonData;

    private void Start()
    {
        if (!JsonSaverLib.Load<PlayerJsonData>(GetHashCode(), out var loadedObject)) return;
        _playerJsonData = loadedObject;
        Inventory.Items = _playerJsonData.Inventory;
        Hotbar.Items = _playerJsonData.Hotbar;
        PlayerHealth.Health = _playerJsonData.Health;
        transform.SetPositionAndRotation(_playerJsonData.Position, _playerJsonData.Rotation);
    }

    private void OnApplicationQuit()
    {
        _playerJsonData ??= new();

        _playerJsonData.Inventory = Inventory.Items;
        _playerJsonData.Hotbar = Hotbar.Items;
        _playerJsonData.Position = transform.position;
        _playerJsonData.Rotation = transform.rotation;
        _playerJsonData.Health = PlayerHealth.Health;

        JsonSaverLib.Save(_playerJsonData, GetHashCode());
    }
}
