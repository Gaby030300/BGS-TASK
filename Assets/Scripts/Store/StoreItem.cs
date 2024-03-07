using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Store Item", menuName = "Store Item")]
public class StoreItem : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    public string description;
    public int price;
    public int quantity;
}