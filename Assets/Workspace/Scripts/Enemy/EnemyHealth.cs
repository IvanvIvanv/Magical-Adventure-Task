using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    public Renderer Renderer;
    public EnemyColor EnemyColor;

    [SerializeField] private float _health = 100f;
    public float Health
    {
        get => _health;
        set
        {
            if (value < _health) StartCoroutine(FlashRoutine());

            _health = value;
            if (_health <= 0) Destroy(gameObject);
        }
    }

    private IEnumerator FlashRoutine()
    {
        Renderer.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        Renderer.material.color = EnemyColor.Color;
    }
}
