using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WindowSource : WindowListContainer
{
    public WindowCreator WindowCreator;
    public WindowNecessariesContainer NecessariesContainer;
    public bool AllowOnlyOneWindow = true;

    public bool IsOpened { get => Windows.Any(); }

    public void CreateWindow(WindowProperties windowProperties)
    {
        if (AllowOnlyOneWindow && IsOpened) return;
        Windows.Add(WindowCreator.CreateWindow(NecessariesContainer.WindowNecessaries, windowProperties));
    }

    public void CloseWindows()
    {
        Windows.ForEach(window => Destroy(window.gameObject));
    }
}