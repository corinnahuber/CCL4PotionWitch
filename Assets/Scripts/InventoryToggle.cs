using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryUI; // Reference to the inventory UI GameObject


    private void Start()
    {
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(false); // Ensure the inventory UI is initially hidden
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Change to your desired key for toggling the inventory
        {
            if (inventoryUI != null)
            {
                bool isActive = inventoryUI.activeSelf;
                inventoryUI.SetActive(!isActive); // Toggle the inventory UI visibility
            }

        }
    }
}

