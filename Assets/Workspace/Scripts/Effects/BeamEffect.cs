using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BeamEffect : MonoBehaviour
{
    public float Damage;

    private ParticleSystem _particleSystem;

    private IEnumerator Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Play();
        yield return new WaitForSeconds(_particleSystem.main.duration);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        DealDamage(other);
        Destroy(gameObject);
    }

    private void DealDamage(Collision other)
    {
        if (!other.gameObject.TryGetComponent<IHealth>(out var iHealth)) return;
        iHealth.Health -= Damage;
    }
}
