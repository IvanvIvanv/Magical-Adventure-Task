using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowListContainer : MonoBehaviour
{
    private List<WindowRoot> _windows = new();
    public List<WindowRoot> Windows
    {
        get
        {
            _windows.RemoveAll(window => window == null);
            return _windows;
        }
        private set => _windows = value;
    }
}
