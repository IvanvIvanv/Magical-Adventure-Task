using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemWand : Item
{
    public abstract string ElementalName { get; }
    [field: SerializeField] public float Cooldown { get; private set; }
}
