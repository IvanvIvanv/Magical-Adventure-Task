using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public Reload Reload;
    public Inventory ConnectedInventory;
    public InteractorCrosshair InteractorCrosshair;
    public ItemSlotsUI ItemSlotsUI;
    public Transform PrefabParent;

    public Color SelectedColor;
    public Color DefaultColor;

    private GameObject _itemHeld;

    private int _selected = 0;
    public int Selected
    {
        get => _selected;
        set
        {
            DeselectSlot();
            _selected = value;
            if (_selected >= ItemSlotsUI.ItemSlots.Count) _selected = 0;
            if (_selected < 0) _selected = ItemSlotsUI.ItemSlots.Count - 1;
            SelectSlot();
        }
    }

    private void Start()
    {
        ItemSlotsUI.Construct(ConnectedInventory);
        SelectSlot();
        ItemSlotsUI.OnAnyItemChanged.AddListener(OnAnyItemChangedHandler);
    }

    public void SelectSlot()
    {
        ItemSlotsUI.ItemSlots[Selected].Image.color = SelectedColor;
        var item = ItemSlotsUI.ItemUIs[Selected].Item;
        if (_itemHeld != null) Destroy(_itemHeld);
        if (item == null) return;
        _itemHeld = Instantiate(item.Prefab, PrefabParent) as GameObject;
        _itemHeld.transform.SetLocalPositionAndRotation(item.HandHeldPosition, Quaternion.Euler(item.HandHeldEuler));
    }

    public void DeselectSlot()
    {
        ItemSlotsUI.ItemSlots[Selected].Image.color = DefaultColor;
    }

    private void OnAnyItemChangedHandler()
    {
        SelectSlot();
    }

    public void TriggerSelected()
    {
        var item = ItemSlotsUI.ItemUIs[Selected].Item;
        if (item == null) return;
        item.Trigger(InteractorCrosshair.RayFromCrosshair);
        Reload.StartCooldown(item.Cooldown);
    }
}
