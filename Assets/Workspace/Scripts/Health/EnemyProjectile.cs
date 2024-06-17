using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float Damage;
    public float LifeTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        DealDamage(other);
        Destroy(gameObject);
    }

    private void DealDamage(Collision other)
    {
        if (!other.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth)) return;
        playerHealth.Health -= Damage;
    }
}
