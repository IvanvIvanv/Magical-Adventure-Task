using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowData
{
    public WindowNecessaries WindowNecessaries;
    public WindowProperties WindowProperties;

    public WindowData(WindowNecessaries windowNecessaries, WindowProperties windowProperties)
    {
        WindowNecessaries = windowNecessaries;
        WindowProperties = windowProperties;
    }
}
