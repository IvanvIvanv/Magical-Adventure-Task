using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public HealthDisplay HealthDisplay;
    private bool _maxHealthFlag;

    [SerializeField] private float _health;
    public float Health 
    {
        get => _health;
        set
        {
            if (!_maxHealthFlag) SetMaxHealth();

            _health = value;
            HealthDisplay.UpdateDisplay(_health / _maxHealth);
            if (_health <= 0) GameOver.Trigger();
        }
    }

    private void SetMaxHealth()
    {
        _maxHealth = Health;
        _maxHealthFlag = true;
    }

    private float _maxHealth;
}
