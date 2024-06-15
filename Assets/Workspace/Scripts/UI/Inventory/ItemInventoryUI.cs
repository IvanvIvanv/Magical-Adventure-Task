using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryUI : Inventory
{
    public List<ItemUI> ItemUIs;
    public override List<Item> Items
    {
        get => _items;
        set
        {
            base.Items = value;

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i] == ItemUIs[i].Item) continue;
                ItemUIs[i].Item = _items[i];
            }
        }
    }
}
