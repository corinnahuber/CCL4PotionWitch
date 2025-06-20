using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryFieldUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;
    public ItemData currentItem; // To track what item this UI field holds

    private int slotIndex;

    private void Awake()
    {

       //not working will try later
        //icon = transform.Find("IngImage").GetComponent<Image>();
        countText = GetComponentInChildren<TextMeshProUGUI>();

        icon.enabled = false; // Initially hide the icon
        countText.enabled = false; 

    }

    public void SetSlot(ItemData item, int quantity, int index)
    {  
        currentItem = item;
        slotIndex = index;

        icon.sprite = item.itemImage; //taking image from the item data
        icon.enabled = true;  // Enable the icon to show the item image

        countText.text = $"x {quantity}";
        countText.color = quantity < item.itemMaxStack ? Color.white : Color.green;
        countText.enabled = true;
    }

    public void ClearSlot()
    {
        icon.enabled = false;
        countText.enabled = false;
        currentItem = null;
    }
}

