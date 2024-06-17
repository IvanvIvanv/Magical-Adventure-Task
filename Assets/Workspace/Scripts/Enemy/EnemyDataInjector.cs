using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataInjector : MonoBehaviour
{
    public EnemyData EnemyData;
    public EnemyHealth EnemyHealth;
    public EnemyDamage EnemyDamage;
    public PlayerMovement EnemyMovement;
    public SphereCollider SpottingRadius;
    public EnemyColor EnemyColor;

    private void Start()
    {
        EnemyHealth.Health = EnemyData.Health;
        EnemyDamage.Damage = EnemyData.Damage;
        EnemyMovement.Speed = EnemyData.Speed;
        SpottingRadius.radius = EnemyData.SpottingRange;
        EnemyColor.Color = EnemyData.Color;
    }
}
