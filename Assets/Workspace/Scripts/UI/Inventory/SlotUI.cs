using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ItemSlotsUI ItemSlotsUI;

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

    private ItemUI _itemUI;
    public ItemUI ItemUI
    {
        get
        {
            if (_itemUI == null) _itemUI = GetComponentInChildren<ItemUI>();
            return _itemUI;
        }
        set => _itemUI = value;
    }

    private Canvas _canvas;
    public Canvas Canvas
    {
        get
        {
            if (_canvas == null) _canvas = GetComponentInParent<Canvas>();
            return _canvas;
        }
        set => _canvas = value;
    }

    private static ItemUI _itemInCursor;
    private static SlotUI _slotSource;
    private static bool _pointerInsideSlot;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_itemInCursor != null) ImportItem();
        else ExportItem();
    }

    private void ImportItem()
    {
        if (ItemUI.Item == null)
        {
            ItemUI.Item = _itemInCursor.Item;
            Destroy(_itemInCursor.gameObject);
            _slotSource = null;
        }
        else
        {
            (ItemUI.Item, _itemInCursor.Item) = (_itemInCursor.Item, ItemUI.Item);
            _slotSource = ItemSlotsUI.ItemUIs.First(itemUI => itemUI.Item == null).SlotUI;
        }
    }

    private void ExportItem()
    {
        if (ItemUI.Item == null) return;
        _itemInCursor = Instantiate(ItemUI, Canvas.transform).GetComponent<ItemUI>();
        _itemInCursor.Item = ItemUI.Item;
        ItemUI.Item = null;
        _slotSource = this;
    }

    private static void ReturnItem()
    {
        _slotSource.ItemUI.Item = _itemInCursor.Item;
        Destroy(_itemInCursor.gameObject);
        _slotSource = null;
    }

    private void Update()
    {
        if (_itemInCursor == null) return;
        _itemInCursor.transform.position = Input.mousePosition;
        if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && _slotSource == this && !_pointerInsideSlot) ReturnItem();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pointerInsideSlot = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pointerInsideSlot = false;
    }
}
