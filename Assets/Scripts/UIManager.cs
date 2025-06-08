using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryUI; // Reference to the inventory UI GameObject

    private bool isOpen = false;

    private void Start()
    {
        inventoryUI.SetActive(isOpen); 
    
    }

    private void Update()
    {
        Debug.Log("UIManager Update called");
        if (Input.GetKeyDown(KeyCode.I)) // Change to your desired key for toggling the inventory

        {
            if (isOpen)
            {
                Debug.Log("Closing inventory");
                inventoryUI.SetActive(false);
                isOpen = false;
            }
            else
            {
                Debug.Log("Opening inventory");
                inventoryUI.SetActive(true);
                isOpen = true;
            }
        }
    }
}
