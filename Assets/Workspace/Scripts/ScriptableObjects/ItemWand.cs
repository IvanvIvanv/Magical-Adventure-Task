using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemWand : Item
{
    public abstract string ElementalName { get; }

    public abstract void Trigger(Transform startPosition);
}
