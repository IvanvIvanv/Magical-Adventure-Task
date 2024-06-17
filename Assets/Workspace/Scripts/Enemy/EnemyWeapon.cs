using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject Projectile;
    public float ForwardOffset;
    public float ShootForce;
    public float Damage;
    public float LifeTime;

    public void Shoot()
    {
        var proj = Instantiate(Projectile, transform.position + transform.forward * ForwardOffset, transform.rotation);
        proj.GetComponent<Rigidbody>().AddForce(transform.forward * ShootForce);
        var enemyProj = proj.GetComponent<EnemyProjectile>();
        enemyProj.Damage = Damage;
        enemyProj.LifeTime = LifeTime;
    }
}
