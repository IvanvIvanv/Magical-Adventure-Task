using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ItemSlotsUI : MonoBehaviour
{
    public GameObject SlotPrefab;
    public GameObject ItemPrefab;

    public List<ItemUI> ItemUIs { get; private set; } = new();
    public List<SlotUI> ItemSlots { get; private set; } = new();

    public readonly UnityEvent OnAnyItemChanged = new();

    private Inventory _connectedInventory;
    private LayoutRebuilder _rebuilder;

    private bool _constructInProgress;

    public void Construct(Inventory connectedInventory)
    {
        _constructInProgress = true;
        _rebuilder = GetComponent<LayoutRebuilder>();
        _connectedInventory = connectedInventory;

        for (int i = 0; i < _connectedInventory.Capacity; i++)
        {
            var slot = Instantiate(SlotPrefab, transform);
            var slotUI = slot.GetComponent<SlotUI>();
            slotUI.ItemSlotsUI = this;
            ItemSlots.Add(slotUI);
            var itemGameObject = Instantiate(ItemPrefab, slot.transform);
            var ItemUI = itemGameObject.GetComponent<ItemUI>();
            ItemUI.OnItemChanged.AddListener(RefreshInventory);
            ItemUI.Item = i < _connectedInventory.Items.Count ? _connectedInventory.Items[i] : null;
            ItemUIs.Add(ItemUI);
        }

        if (_rebuilder != null) _rebuilder.Rebuild();
        _constructInProgress = false;
    }

    private void RefreshInventory()
    {
        if (_constructInProgress) return;
        _connectedInventory.Items = ItemUIs.Select(itemUI => itemUI.Item).ToList();
        OnAnyItemChanged.Invoke();
    }
}
