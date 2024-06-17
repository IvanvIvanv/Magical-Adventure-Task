using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Objects/Enemy", order = 3)]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public Object RangedWeapon { get; private set; }
}
