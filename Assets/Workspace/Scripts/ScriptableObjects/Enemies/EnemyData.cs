using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Objects/Enemy", order = 3)]
public class EnemyData : ScriptableObject
{
    public Color Color = Color.white;
    [field: SerializeField] public float Damage { get; private set; } = 10f;
    [field: SerializeField] public float Health { get; private set; } = 100f;
    [field: SerializeField] public float Speed { get; private set; } = 100f;
    [field: SerializeField] public float SpottingRange { get; private set; } = 5f;
    [field: SerializeField] public Object RangedWeapon { get; private set; }
}
