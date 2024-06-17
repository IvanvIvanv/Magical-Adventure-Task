using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Enemy", menuName = "Scriptable Objects/Enemies/Ranged Enemy", order = 4)]
public class RangedEnemy : EnemyData
{
    [field: SerializeField] public Object RangedWeapon { get; private set; }
    [field: SerializeField] public Vector3 WeaponLocalPosition { get; private set; }
    [field: SerializeField] public Vector3 WeaponLocalEuler { get; private set; }
    [field: SerializeField] public float ShootCooldown { get; private set; }
}
