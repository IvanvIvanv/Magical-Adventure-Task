using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffectOnDestroy : MonoBehaviour
{
    public GameObject Prefab;

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        Instantiate(Prefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
    }
}
