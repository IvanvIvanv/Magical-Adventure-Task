using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private Image _image;

    private Item _item;
    public Item Item
    {
        get => _item;
        set
        {
            _item = value;
            if (_item == null) return;
            Image.sprite = _item.Icon;
        }
    }

    public Image Image
    {
        get
        {
            if (_image == null) _image = GetComponent<Image>();
            return _image;
        }
        set => _image = value;
    }
}
