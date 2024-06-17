using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

[CreateAssetMenu(fileName = "New Physical Wand", menuName = "Scriptable Objects/Wands/BeamWand", order = 2)]
public class BeamWand : ItemWand
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Offset { get; private set; }
    [field: SerializeField] public GameObject EffectPrefab { get; private set; }
    public override string ElementalName => "Beam";

    public override void Trigger(Ray ray)
    {
        var raySphere = Instantiate(EffectPrefab, ray.origin + ray.direction * Offset, Quaternion.Euler(ray.direction));
        raySphere.GetComponent<BeamEffect>().Damage = Damage;
        raySphere.GetComponent<Rigidbody>().AddForce(ray.direction * Speed);
    }
}