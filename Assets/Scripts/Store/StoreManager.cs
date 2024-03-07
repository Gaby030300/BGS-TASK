using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [Header("Store Items")]
    [SerializeField] private  List<StoreItem> items = new List<StoreItem>();
    
    [Header("UI Store Panel")]
    [SerializeField] private  RectTransform content; 
    [SerializeField] private  GameObject storeItemPrefab;

    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (storeItemPrefab != null)
            {
                GameObject storeItem = Instantiate(storeItemPrefab, content);
                storeItem.transform.localScale = Vector3.one;
                StoreItemUI itemUI = storeItem.GetComponent<StoreItemUI>();
                if (itemUI != null)
                {
                    itemUI.SetItem(items, i); 
                }
            }
        }
    }
}
