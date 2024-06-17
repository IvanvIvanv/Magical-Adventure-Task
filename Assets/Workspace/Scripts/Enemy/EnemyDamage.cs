using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float Damage = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth)) return;
        playerHealth.Health -= Damage;
    }
}
