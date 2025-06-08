using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUi : MonoBehaviour
{
    public static InventoryUi inventoryInstance = null;

    public InventoryFieldUI[] inventoryFields = new InventoryFieldUI[15]; // Assign in Inspector

    private void Awake()
    {
        if (inventoryInstance == null) inventoryInstance = this;
        else Destroy(this);

    }


    public void RefreshAllUI(List<InventorySlot> slots)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventoryFields.Length)
            {
                var slot = slots[i];
                Debug.Log($"Populating UI slot {i} with item {slot.itemData.itemName} x{slot.quantity}");
                inventoryFields[i].GetComponent<InventoryFieldUI>().SetSlot(slot.itemData, slot.quantity, i);
            }
        }
    }
}

