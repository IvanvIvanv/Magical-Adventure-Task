using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WindowCreator : MonoBehaviour
{
    public Vector2 CreatedWindowOffset = new(5f, -5f);
    public Vector2 DefaultSize = new(200f, 200f);

    public readonly UnityEvent<WindowRoot> OnWindowCreated = new();

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

    public WindowRoot LatestCreated { get => Windows.LastOrDefault(); }

    private static int _windowIndex;
    public static int WindowIndex 
    {
        get
        {
            return _windowIndex++;
        }
    }

    public WindowRoot CreateWindow(WindowNecessaries windowNecessaries, WindowProperties windowProperties)
    {
        var window = Instantiate(windowProperties.Prefab, transform);
        window.name = "Window " + WindowIndex;

        var windowRect = window.GetComponent<RectTransform>();
        windowRect.SetPivot(new(0.5f, 0.5f));
        if (LatestCreated == null) PositionInCenter(windowNecessaries, windowRect);
        else PositionInLatest(windowRect);
        windowRect.WrapInRect(windowNecessaries.ParentRectTransform);

        var root = window.GetComponent<WindowRoot>();
        SetWindowProperties(root, windowProperties);
        root.Construct(windowNecessaries);

        Windows.Add(root);
        OnWindowCreated.Invoke(root);
        return root;
    }

    private void PositionInCenter(WindowNecessaries windowNecessaries, RectTransform windowRect)
    {
        windowRect.anchoredPosition = windowNecessaries.ParentRectTransform.rect.center;
        windowRect.sizeDelta = DefaultSize;
    }

    private void PositionInLatest(RectTransform windowRect)
    {
        var latestRect = LatestCreated.GetComponent<RectTransform>();
        latestRect.SetPivot(new(0.5f, 0.5f));
        windowRect.anchoredPosition = latestRect.anchoredPosition + CreatedWindowOffset;
        windowRect.sizeDelta = latestRect.sizeDelta;
    }

    private void SetWindowProperties(WindowRoot root, WindowProperties windowProperties)
    {
        if (windowProperties.Name != null) root.SetName(windowProperties.Name);
        root.SetColor(windowProperties.Color);
        if (windowProperties.ContentPrefab != null) root.SetContent(windowProperties.ContentPrefab);
        root.SetCloseDistance(windowProperties.WindowCloseDistance, windowProperties.WindowSource);
    }

    public void SetInteractionAll(bool isActive)
    {
        Windows.ForEach(window => window.SetInteraction(isActive));
    }
}
