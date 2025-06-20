using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{

    public static Inventory instance= null; // Singleton instance of the inventory!

    public List<InventorySlot> inventoryItems = new List<InventorySlot>();


    private void Awake()
    {
        // there is only one instance of the inventory!
        if (instance == null) instance = this;
        else Destroy(this);
        
        
    }

    public bool AddItem(ItemData item)
    {
        var existingSlot = inventoryItems.Find(slot => slot.itemData == item);

        if (existingSlot != null && existingSlot.quantity < item.itemMaxStack)
        {
            existingSlot.quantity++;
        }
        else if (inventoryItems.Count < InventoryUi.inventoryInstance.inventoryFields.Length)
        {
            inventoryItems.Add(new InventorySlot(item));
        }
        else
        {
            Debug.Log("Inventory full!");
            return false;
        }

        InventoryUi.inventoryInstance.RefreshAllUI(inventoryItems);
        return true;
    }
}