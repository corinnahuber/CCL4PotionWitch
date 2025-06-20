using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour
{
    public static Book bookInstance { get; private set; }
    public List<InventorySlot> ingredientsList = new List<InventorySlot>();

    [SerializeField]
    public List<PotionData> potionsList = new List<PotionData>();
    public int CurrentPotionIndex { get; private set; } = 0;



    private void Awake()
    {
        if (bookInstance == null)
        {
            bookInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (bookInstance != this)
        {
            Destroy(gameObject); // Prevent duplicate
            return;
        }
    }


    public PotionData GetCurrentPotion()
    {
        if (potionsList.Count == 0)
            return null;
        return potionsList[CurrentPotionIndex]; // Return the current potion based on the index
    }

    public void ToRight()
    {
        if (CurrentPotionIndex < potionsList.Count - 1)
            CurrentPotionIndex++;
        AreAllIngredientsInInventory();

    }

    public void ToLeft()
    {
        if (CurrentPotionIndex > 0)
            CurrentPotionIndex--;
        AreAllIngredientsInInventory();
    }


    public bool IsAtFirstPotion() => CurrentPotionIndex == 0;
    public bool IsAtLastPotion() => CurrentPotionIndex == potionsList.Count - 1;


    public void BrewPotion()
    {
        if (AreAllIngredientsInInventory())
        {
            RemoveUsedIngredients(); // Remove ingredients from inventory

            PotionInventory.instance.AddPotion(GetCurrentPotion()); 

            /*
            if (potionsList.Count == 1)
            {
                PotionsInventoryUI.instance.selectedIndex = 0; // If this is the only potion, select it
            }*/

            PotionsInventoryUI.instance.PotionInventoryUIUpdate(); // Update the potion inventory UI
        }
        
    }


    public bool AreAllIngredientsInInventory()
    {
        PotionData currentPotion = GetCurrentPotion();
        if (currentPotion == null)
            return false; // No potion selected, cannot check ingredients
        

        foreach (var ingredient in currentPotion.potionIngredients)
        {
            if (!Inventory.instance.inventoryItems.Exists(slot => slot.itemData == ingredient))
            {
                return false; // If any ingredient is not in the inventory, return false
            }
        }
        return true; // All ingredients are in the inventory
    }


    public void RemoveUsedIngredients()
    {
        PotionData currentPotion = GetCurrentPotion();
        Debug.Log("Removing ingredients for potion: " + potionsList.IndexOf(currentPotion) + " - " + currentPotion.potionName);
        if (currentPotion == null)
            return; // No potion selected, cannot remove ingredients


        foreach (var ingredient in currentPotion.potionIngredients)
        {
            var existingSlot = Inventory.instance.inventoryItems.Find(slot => slot.itemData == ingredient);
            {
                if (existingSlot == null) continue;

                existingSlot.quantity--;
                if (existingSlot.quantity <= 0) // If the quantity is now 0 or less
                {
                    Inventory.instance.inventoryItems.Remove(existingSlot); // Remove the slot if quantity is now 0
                   
                }
            }

        }
        InventoryUi.inventoryInstance.RefreshAllUI(Inventory.instance.inventoryItems); //needs to refresh the inventory UI too!
    }
}
    
