using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowGrabber : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public RectTransform WindowRect;
    public RectTransform ParentRect;
    public Canvas Canvas;

    private Vector2 _previousPointerPosition;
    private Vector2 _currentPointerPosition;


    public void OnBeginDrag(PointerEventData data)
    {
        WindowRect.SetAsLastSibling();

        _previousPointerPosition = data.position / Canvas.scaleFactor;
    }

    public void OnDrag(PointerEventData data)
    {
        _currentPointerPosition = data.position / Canvas.scaleFactor;
        
        Vector2 transformValue = _currentPointerPosition - _previousPointerPosition;
        WindowRect.anchoredPosition += transformValue;
        WindowRect.KeepFullyOnScreen(ParentRect);

        _previousPointerPosition = _currentPointerPosition;
    }

}
