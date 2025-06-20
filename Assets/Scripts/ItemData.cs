using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this sript is used to define the data structure for each item that can be collected in the game.
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject

{
    public string itemName;
    public Sprite itemImage;
    public int itemMaxStack = 8;
}
