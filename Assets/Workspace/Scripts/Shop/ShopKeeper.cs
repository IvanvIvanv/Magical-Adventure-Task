using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    [SerializeField] private string _name;
    public string Name { get => _name; }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
