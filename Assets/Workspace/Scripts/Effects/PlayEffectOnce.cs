using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class PlayEffectOnce : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private IEnumerator Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Play();
        yield return new WaitForSeconds(_particleSystem.main.duration);
        Destroy(gameObject);
    }
}
