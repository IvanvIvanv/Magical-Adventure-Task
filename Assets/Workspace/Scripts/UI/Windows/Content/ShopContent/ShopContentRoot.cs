using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(WindowDataContainer))]
public class ShopContentRoot : ContentRoot
{
    public TextMeshProUGUI ShopTextUGUI;
    public Transform ItemContainer;

    public WindowShopProperties WindowShopProperties { get; private set; }

    protected override void Start()
    {
        base.Start();

        WindowShopProperties = (WindowShopProperties)WindowProperties;
        ShopTextUGUI.text = WindowShopProperties.ShopText;
    }
}
