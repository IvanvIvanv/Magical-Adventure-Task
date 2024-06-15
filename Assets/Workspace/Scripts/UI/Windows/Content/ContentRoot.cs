using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentRoot : MonoBehaviour
{
    public WindowProperties WindowProperties { get; private set; }

    private WindowDataContainer _dataContainer;

    protected virtual void Start()
    {
        _dataContainer = GetComponent<WindowDataContainer>();
        WindowProperties = _dataContainer.WindowData.WindowProperties;
    }
}
