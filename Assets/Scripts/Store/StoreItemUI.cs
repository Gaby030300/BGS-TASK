using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    [Header(("Store Item Properties"))]
    [SerializeField] private StoreItem storeItem;
    [SerializeField] private  TMP_Text itemNameText;
    [SerializeField] private  TMP_Text itemPriceText;
    [SerializeField] private  Image spriteImage;
    
    [Header("Buy Button")]
    [SerializeField] private  Button buyButton;

    private InventoryUI _inventoryManager;
    
    private void Start()
    {
        _inventoryManager = FindObjectOfType<InventoryUI>();
        buyButton.onClick.AddListener(BuyItem);
    }

    public void SetItem(List<StoreItem> items, int index)
    {
        if (index < 0 || index >= items.Count) return;
        
        storeItem = items[index];
        itemNameText.text = storeItem.itemName;
        itemPriceText.text = "$" + storeItem.price.ToString();
        spriteImage.sprite = storeItem.sprite;
    }

    private void BuyItem()
    {
        _inventoryManager.AddToInventory(storeItem);
    }
}
