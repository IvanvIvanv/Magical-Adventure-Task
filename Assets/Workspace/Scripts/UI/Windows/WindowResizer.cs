using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowResizer : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform WindowRect;
    public Vector2 MinSize;
    public Vector2 MaxSize;

    private Vector2 _currentPointerPosition;
    private Vector2 _previousPointerPosition;

    public void OnPointerDown(PointerEventData data)
    {
        WindowRect.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(WindowRect, data.position, data.pressEventCamera, out _previousPointerPosition);
    }

    public void OnDrag(PointerEventData data)
    {
        Vector2 sizeDelta = WindowRect.sizeDelta;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(WindowRect, data.position, data.pressEventCamera, out _currentPointerPosition);
        Vector2 resizeValue = _currentPointerPosition - _previousPointerPosition;

        sizeDelta += new Vector2(resizeValue.x, resizeValue.y);
        sizeDelta = new Vector2(
            Mathf.Clamp(sizeDelta.x, MinSize.x, MaxSize.x),
            Mathf.Clamp(sizeDelta.y, MinSize.y, MaxSize.y)
            );

        WindowRect.sizeDelta = sizeDelta;

        _previousPointerPosition = _currentPointerPosition;
    }
}
