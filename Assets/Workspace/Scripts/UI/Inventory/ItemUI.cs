using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public readonly UnityEvent OnItemChanged = new();

    private Item _item;
    public Item Item
    {
        get => _item;
        set
        {
            bool invokeOnChanged;
            invokeOnChanged = value != _item;
            _item = value;
            Image.enabled = _item != null;
            if (invokeOnChanged) OnItemChanged.Invoke();
            if (_item == null) return;
            Image.sprite = _item.Icon;
        }
    }

    private Image _image;
    public Image Image
    {
        get
        {
            if (_image == null) _image = GetComponent<Image>();
            return _image;
        }
        set => _image = value;
    }

    private SlotUI _slotUI;
    public SlotUI SlotUI
    {
        get
        {
            if (_slotUI == null) _slotUI = GetComponentInParent<SlotUI>();
            return _slotUI;
        }
        set => _slotUI = value;
    }
}
