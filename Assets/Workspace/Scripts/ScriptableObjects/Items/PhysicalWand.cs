using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Physical Wand", menuName = "Scriptable Objects/Wands/PhysicalWand", order = 1)]
public class PhysicalWand : ItemWand
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Range { get; private set; }
    [field: SerializeField] public GameObject EffectPrefab { get; private set; }

    public override string ElementalName => "Physical";

    public override void Trigger(Ray ray)
    {
        if (!Physics.Raycast(ray, out var hitInfo, Range)) return;
        if (!hitInfo.collider.TryGetComponent<IHealth>(out var iHealth)) return;
        Instantiate(EffectPrefab, hitInfo.point, Quaternion.Euler(-90f, 0f, 0f));
        iHealth.Health -= Damage;
    }
}
