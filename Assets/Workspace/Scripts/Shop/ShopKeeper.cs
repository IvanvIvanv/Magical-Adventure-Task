using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    [SerializeField] private string _interactionText;
    public string InteractionText { get => _interactionText; }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
