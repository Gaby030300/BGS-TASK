using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _alertIcon;
    [SerializeField] private Button _buttonInventory, _buttonClose;
    [SerializeField] private CanvasGroup _storePanel, _inventoryPanel;

    private void Start()
    {
        _buttonInventory.onClick.AddListener(OpenInventory);
        _buttonClose.onClick.AddListener(CloseInventory);
    }
    private void Update()
    {
        
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _alertIcon.SetActive(true);
            if(InputManager.EPressed)
                Debug.Log("se presiono");
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
