using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public HealthDisplay HealthDisplay;

    [SerializeField] private float _health;
    public float Health 
    {
        get => _health;
        set
        {
            _health = value;
            HealthDisplay.UpdateDisplay(_health / _maxHealth);
            if (_health <= 0) Destroy(gameObject);
        }
    }

    private float _maxHealth;

    private void Start()
    {
        _maxHealth = Health;
    }
}
