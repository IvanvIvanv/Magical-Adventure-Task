using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WindowCreator))]
public class MapSwitchWindowDisabler : MonoBehaviour
{
    public ActionMapSwitcher ActionMapSwitcher;
    
    public bool IsPlayer { get; private set; }

    private WindowCreator _windowCreator;

    private void Start()
    {
        _windowCreator = GetComponent<WindowCreator>();
        ActionMapSwitcher.OnControlModeSwitched.AddListener(SetInteractionWindows);
        _windowCreator.OnWindowCreated.AddListener(OnWindowCreatedHandler);
    }

    private void SetInteractionWindows(bool isPlayer)
    {
        _windowCreator.SetInteractionAll(!isPlayer);
        IsPlayer = isPlayer;
    }

    private void OnWindowCreatedHandler(WindowRoot root)
    {
        root.SetInteraction(!IsPlayer);
    }
}
