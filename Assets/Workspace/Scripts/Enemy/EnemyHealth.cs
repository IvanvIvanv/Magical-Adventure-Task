using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float _health = 100f;
    public float Health
    {
        get => _health;
        set
        {
            _health = value;
            if (_health <= 0) Destroy(gameObject);
        }
    }
}
