using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    public WindowCreator WindowCreator;
    public WindowNecessariesContainer NecessariesContainer;
    public WindowShopProperties WindowProperties;

    [SerializeField] private string _interactionText;
    public string InteractionText { get => _interactionText; }

    private WindowRoot _shopWindow;

    public void Interact()
    {
        if (_shopWindow != null) return;
        _shopWindow = WindowCreator.CreateWindow(NecessariesContainer.WindowNecessaries, WindowProperties);
    }
}