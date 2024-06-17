using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    public Inventory Inventory;
    public Inventory Hotbar;

    private PlayerJsonData _playerJsonData;

    private void Start()
    {
        _playerJsonData = JsonSaverLib.Load<PlayerJsonData>(GetHashCode());

        Inventory = _playerJsonData.Inventory;
        Hotbar = _playerJsonData.Hotbar;
        transform.position = _playerJsonData.Position;
        transform.rotation = _playerJsonData.Rotation;
    }

    private void OnApplicationQuit()
    {
        JsonSaverLib.Save(_playerJsonData, GetHashCode());
    }
}
