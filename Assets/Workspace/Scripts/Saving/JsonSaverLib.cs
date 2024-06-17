using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static UnityEngine.JsonUtility;

public static class JsonSaverLib
{
    public static readonly string _savingPath = "/Json";

    public static void Save<T>(T obj, int hash)
    {
        var path = Application.persistentDataPath + _savingPath + "/" + hash + ".json";
        var json = ToJson(obj);
        File.WriteAllText(path, json);
    }

    public static T Load<T>(int hash)
    {
        var path = Application.persistentDataPath + _savingPath + hash + ".json"; ;
        var json = File.ReadAllText(path);
        return FromJson<T>(json);
    }

    public static void ClearFolder()
    {
        Directory.Delete(Application.persistentDataPath + _savingPath);
    }
}