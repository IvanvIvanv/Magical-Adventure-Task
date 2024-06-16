using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractorCrosshair : MonoBehaviour
{
    public float MaxDistance = 2f;
    public TextMeshProUGUI _interactorTmpu;
    private RectTransform _rectTransform;
    private IInteractable _objectInCrosshair;

    public Ray RayFromCrosshair { get => Camera.main.ScreenPointToRay(_rectTransform.position); }

private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!RaycastInteraction()) ClearCrosshair();
    }

    private bool RaycastInteraction()
    {
        Ray ray = RayFromCrosshair;
        if (!Physics.Raycast(ray, out var hitInfo, MaxDistance)) return false;
        if (!hitInfo.collider.TryGetComponent<IInteractable>(out var iinteractable)) return false;
        _objectInCrosshair = iinteractable;
        _interactorTmpu.text = iinteractable.InteractionText;
        return true;
    }

    private void ClearCrosshair()
    {
        _objectInCrosshair = null;
        _interactorTmpu.text = string.Empty;
    }

    public void Interact()
    {
        _objectInCrosshair?.Interact();
    }
}
