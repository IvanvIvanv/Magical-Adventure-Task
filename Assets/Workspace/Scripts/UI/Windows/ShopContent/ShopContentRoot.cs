using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(WindowDataContainer))]
public class ShopContentRoot : MonoBehaviour
{
    public TextMeshProUGUI ShopTextUGUI;
    public Transform ItemContainer;

    public WindowShopProperties WindowShopProperties { get; private set; }

    private WindowDataContainer _dataContainer;

    private void Start()
    {
        _dataContainer = GetComponent<WindowDataContainer>();
        WindowShopProperties = (WindowShopProperties)_dataContainer.WindowData.WindowProperties;
        ShopTextUGUI.text = WindowShopProperties.ShopText;
    }
}
