using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : WindowSource, IInteractable
{
    public string InteractionText => "Open chest";
    public WindowInventoryProperties InventoryProperties;
    public WindowCreator Creator;

    public void Interact()
    {
        CreateWindow(InventoryProperties);
    }
}
