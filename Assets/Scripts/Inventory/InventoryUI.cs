using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Inventory Elements")]
    [SerializeField] private  List<StoreItem> inventory = new List<StoreItem>();
    
    [Header(("Inventory UI"))]
    [SerializeField] private  GameObject inventoryUIPrefab;
    [SerializeField] private  Transform inventoryContent;
    
    [Header("Inventory Elements Properties")]
    [SerializeField] private  TMP_Text descriptionText;
    [SerializeField] private  TMP_Text quantityText;
    [SerializeField] private  Image iconObject;
    
    public void AddToInventory(StoreItem item)
    {
        foreach (var inventoryItem in inventory)
        {
            if (inventoryItem.itemName == item.itemName)
            {
                inventoryItem.quantity++;
                UpdateInventoryUI();
                return;
            }
        }

        item.quantity = 1;
        inventory.Add(item);
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryContent)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var item in inventory)
        {
            GameObject newItem = Instantiate(inventoryUIPrefab, inventoryContent);

            newItem.transform.Find("Icon").GetComponent<Image>().sprite = item.sprite;
            newItem.transform.Find("Quantity").GetComponent<TMP_Text>().text = "x" + item.quantity.ToString(); 
            
            Button button = newItem.GetComponent<Button>();
            
            button.onClick.AddListener(() =>
            {
                ShowDescription(item.description, "Quantity: " + item.quantity.ToString(), item.sprite);
            });        
        }
    }
    
    private void ShowDescription(string description, string quantity, Sprite icon)
    {
        descriptionText.text = description;
        quantityText.text = quantity;
        iconObject.sprite = icon;
    }
}

