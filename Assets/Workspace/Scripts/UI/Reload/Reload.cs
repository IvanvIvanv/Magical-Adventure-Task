using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public bool CanShoot { get; private set; } = true;

    private Image _image;

    public void StartCooldown(float seconds)
    {
        if (CanShoot) StartCoroutine(Cooldown(seconds));
    }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private IEnumerator Cooldown(float seconds)
    {
        CanShoot = false;

        float remainingTime = seconds;
        while (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            _image.fillAmount = remainingTime / seconds;
            yield return null;
        }

        CanShoot = true;
    }
}
