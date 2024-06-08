using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractorCrosshair : MonoBehaviour
{
    public float MaxDistance = 2f;
    public TextMeshProUGUI _interactorTmpu;
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!RaycastInteraction()) _interactorTmpu.text = string.Empty;
    }

    private bool RaycastInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(_rectTransform.position);
        if (!Physics.Raycast(ray, out var hitInfo, MaxDistance)) return false;
        if (!hitInfo.collider.TryGetComponent<IInteractable>(out var iinteractable)) return false;
        _interactorTmpu.text = iinteractable.Name;
        return true;
    }
}
