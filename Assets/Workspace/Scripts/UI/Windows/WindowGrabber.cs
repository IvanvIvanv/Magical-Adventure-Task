using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowGrabber : MonoBehaviour, IDragHandler
{
    public RectTransform WindowRect;
    public Canvas Canvas;
    public WindowInputBinder WindowInputBinder;

    public void OnDrag(PointerEventData eventData)
    {
        WindowRect.anchoredPosition += WindowInputBinder.MouseDelta / Canvas.scaleFactor;
    }
}
