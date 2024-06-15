using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : WindowSource, IInteractable
{
    public WindowShopProperties WindowShopProperties;

    [SerializeField] private string _interactionText;
    public string InteractionText { get => _interactionText; }

    public void Interact()
    {
        CreateWindow(WindowShopProperties);
    }
}