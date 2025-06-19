using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will keep track of the quantity of items in the inventory!!
[System.Serializable]
public class InventorySlot  
{
    public ItemData itemData;
    public int quantity;

    public InventorySlot(ItemData item) // Constructor to initialize the slot with an item
    {
        itemData = item;
        quantity = 1; // Start with 1 when a new item is added
    }
}

