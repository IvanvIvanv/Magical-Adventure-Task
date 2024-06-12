using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowResizer : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform WindowRect;
    public WindowRoot Root;

    public Vector2 MinSize;
    public Vector2 MaxSize;
    public Vector2 ResizeDirection = new(1f, 1f);

    private Vector2 _currentPointerPosition;
    private Vector2 _previousPointerPosition;

    public void OnPointerDown(PointerEventData data)
    {
        WindowRect.SetAsLastSibling();
        WindowRect.SetPivot(DirectionToPivot());

        RectTransformUtility.ScreenPointToLocalPointInRectangle(WindowRect, data.position, data.pressEventCamera, out _previousPointerPosition);
    }

    private Vector2 DirectionToPivot()
    {
        return new(Mathf.InverseLerp(1f, -1f, ResizeDirection.x), Mathf.InverseLerp(1f, -1f, ResizeDirection.y));
    }

    public void OnDrag(PointerEventData data)
    {
        Vector2 sizeDelta = WindowRect.sizeDelta;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(WindowRect, data.position, data.pressEventCamera, out _currentPointerPosition);
        Vector2 resizeValue = _currentPointerPosition - _previousPointerPosition;

        sizeDelta += new Vector2(resizeValue.x, resizeValue.y) * ResizeDirection;
        sizeDelta = new Vector2(
            Mathf.Clamp(sizeDelta.x, MinSize.x, MaxSize.x),
            Mathf.Clamp(sizeDelta.y, MinSize.y, MaxSize.y)
            );

        WindowRect.sizeDelta = sizeDelta;
        WindowRect.ResizeFullyOnScreen(Root.WindowNecessaries.ParentRectTransform);

        _previousPointerPosition = _currentPointerPosition;
    }
}
