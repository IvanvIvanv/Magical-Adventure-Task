using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Physical Wand", menuName = "Scriptable Objects/Wands/PhysicalWand", order = 1)]
public class PhysicalWand : ItemWand
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Range { get; private set; }

    public override string ElementalName => "Physical";

    public override void Trigger(Transform startPosition)
    {
        throw new System.NotImplementedException();
    }
}
