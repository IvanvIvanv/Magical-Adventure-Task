using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] protected List<Item> _items;
    public virtual List<Item> Items
    {
        get => _items;
        set
        {
            if (value.Count > Capacity) throw new System.Exception("Amount of items is exceeding capacity");
            _items = value;
        }
    }

    public int Capacity = 12;
}