using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public RectTransform Container;
    public RectTransform Fill;

    public void UpdateDisplay(float health01)
    {
        Fill.sizeDelta = new(Mathf.Lerp(0f, Container.sizeDelta.x, health01), Fill.sizeDelta.y);
    }
}
