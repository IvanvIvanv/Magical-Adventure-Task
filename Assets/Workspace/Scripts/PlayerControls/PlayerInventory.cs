using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : WindowSource
{
    public WindowInventoryProperties WindowProperties;

    public void OpenInventory()
    {
        CreateWindow(WindowProperties);
    }

    public void CloseInventory()
    {
        CloseWindows();
    }

    public void ToggleInventory()
    {
        if (IsOpened) CloseInventory();
        else OpenInventory();
    }
}
