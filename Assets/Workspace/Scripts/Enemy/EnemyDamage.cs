using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [System.NonSerialized] public EnemyData EnemyData;

    private readonly List<PlayerHealth> _collidingPlayerHealths = new();

    private void OnCollisionEnter(Collision collision)
    {
        if (EnemyData is RangedEnemy) return;
        if (!collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth)) return;
        _collidingPlayerHealths.Add(playerHealth);
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if (!collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth)) return;
        _collidingPlayerHealths.Remove(playerHealth);
    }

    public void StartAttacking()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        if (EnemyData is RangedEnemy) yield break;

        while(true)
        {
            yield return new WaitForSeconds(EnemyData.CloseAttackCooldown);
            _collidingPlayerHealths.ForEach(playerHealth => playerHealth.Health -= EnemyData.Damage);
        }
    }
}
