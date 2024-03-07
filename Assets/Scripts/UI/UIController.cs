using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Icon Notification Store")]
    [SerializeField] private GameObject _alertIcon;
    
    [Header("Interactive Buttons UI")]
    [SerializeField] private Button _buttonInventory, _buttonClose, _buttonCloseStore;
    
    [Header("Store and Inventory Panels UI")]
    [SerializeField] private CanvasGroup _storePanel, _inventoryPanel;

   private void Start()
    {
        _buttonInventory.onClick.AddListener(OpenInventory);
        _buttonClose.onClick.AddListener(CloseInventory);
        _buttonCloseStore.onClick.AddListener(CloseStore);
    }

    private void OpenInventory()
    {
        _inventoryPanel.alpha = 1f;
        _inventoryPanel.blocksRaycasts = true;
        _inventoryPanel.interactable = true;
        Time.timeScale = 0f;
    }
    private void CloseInventory()
    {
        _inventoryPanel.alpha = 0f;
        _inventoryPanel.blocksRaycasts = false;
        _inventoryPanel.interactable = false;
        Time.timeScale = 1f;
    }
    
    private void CloseStore()
    {
        _storePanel.alpha = 0f;
        _storePanel.blocksRaycasts = false;
        _storePanel.interactable = false;
        
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _alertIcon.SetActive(true);
       
            _storePanel.alpha = 1f;
            _storePanel.interactable = true;
            _storePanel.blocksRaycasts = true;

            Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _alertIcon.SetActive(false);
        }
    }
}
