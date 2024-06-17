using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataInjector : MonoBehaviour
{
    public EnemyData EnemyData;
    public EnemyHealth EnemyHealth;
    public EnemyDamage EnemyDamage;
    public PlayerMovement EnemyMovement;
    public EnemyController EnemyController;
    public SphereCollider SpottingRadius;
    public EnemyColor EnemyColor;

    private void Start()
    {
        EnemyDamage.EnemyData = EnemyData;
        EnemyMovement.Speed = EnemyData.Speed;
        SpottingRadius.radius = EnemyData.SpottingRange;
        EnemyColor.Color = EnemyData.Color;
        EnemyDamage.StartAttacking();

        if (EnemyData is not RangedEnemy rangedEnemy) return;
        var weapon = (GameObject)Instantiate(rangedEnemy.RangedWeapon, transform);
        weapon.transform.SetLocalPositionAndRotation(rangedEnemy.WeaponLocalPosition, Quaternion.Euler(rangedEnemy.WeaponLocalEuler));
        var enemyWeapon = weapon.GetComponent<EnemyWeapon>();
        enemyWeapon.Damage = rangedEnemy.Damage;
        enemyWeapon.ShootForce = rangedEnemy.ShootForce;
        enemyWeapon.Damage = rangedEnemy.Damage;
        enemyWeapon.LifeTime = rangedEnemy.ProjectileLifeTime;
        StartCoroutine(ShootRoutine(rangedEnemy.ShootCooldown, enemyWeapon, rangedEnemy.WeaponLocalEuler.x));
    }

    private IEnumerator ShootRoutine(float cooldown, EnemyWeapon enemyWeapon, float verticalOffset)
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            if (EnemyController.ClosestTarget == null) continue;
            enemyWeapon.transform.LookAt(EnemyController.ClosestTarget);
            enemyWeapon.transform.Rotate(new(verticalOffset, 0f, 0f));
            enemyWeapon.Shoot();
        }
    }
}
