using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContentRoot : ContentRoot
{
    public ItemSlotsUI ItemSlotsUI;

    public WindowInventoryProperties WindowInventoryProperties { get; private set; }

    protected override void Start()
    {
        base.Start();

        WindowInventoryProperties = (WindowInventoryProperties)WindowProperties;
        ItemSlotsUI.Construct(WindowInventoryProperties.ConnectedInventory);
    }
}
