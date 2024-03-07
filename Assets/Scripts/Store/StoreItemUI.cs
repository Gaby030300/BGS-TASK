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
    private StoreManager _storeManager;


    [Header("Audio Source")] 
    [SerializeField] private AudioSource _audioSource; 
    
   
    private void Start()
    {
        _inventoryManager = FindObjectOfType<InventoryUI>();
        _storeManager = FindObjectOfType<StoreManager>();
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
        if (_storeManager.playerMoney >= storeItem.price)
        {
            _storeManager.playerMoney -= storeItem.price;
            _storeManager.moneyText.text = "$" + _storeManager.playerMoney;
            _audioSource.Play();
            _inventoryManager.AddToInventory(storeItem);
        }
        else
        {
            Debug.Log("Not enough money to buy " + storeItem.itemName);
        }
    }
}
