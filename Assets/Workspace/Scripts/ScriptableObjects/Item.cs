using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item", order = 1)]
public abstract class Item : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public float Cost { get; private set; }
    [field: SerializeField] public Object Prefab { get; private set; }
    [field: SerializeField] public Vector3 HandHeldPosition { get; private set; }
    [field: SerializeField] public Vector3 HandHeldEuler { get; private set; }

    public abstract void Trigger(Ray ray);
}