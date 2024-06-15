using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotsUI : MonoBehaviour
{
    public GameObject SlotPrefab;
    public GameObject ItemPrefab;

    public List<ItemUI> ItemUIs { get; private set; } = new();

    private LayoutRebuilder _rebuilder;

    public void Construct(Inventory connectedInventory)
    {
        _rebuilder = GetComponent<LayoutRebuilder>();

        foreach (var item in connectedInventory.Items)
        {
            var slot = Instantiate(SlotPrefab, transform);
            var itemGameObject = Instantiate(ItemPrefab, slot.transform);
            var ItemUI = itemGameObject.GetComponent<ItemUI>();
            ItemUI.Item = item;
            ItemUIs.Add(ItemUI);
        }

        _rebuilder.Rebuild();
    }
}
