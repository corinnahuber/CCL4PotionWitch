using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public static Book bookInstance { get; private set; }

    [SerializeField] public List<PotionData> potionsList = new List<PotionData>();
    public int CurrentPotionIndex { get; private set; } = 0;

    private void Awake()
    {
        if (bookInstance == null)
            bookInstance = this;
        else Destroy(gameObject);
    }

    public PotionData GetCurrentPotion()
    {
        if (potionsList.Count == 0)
            return null;
        return potionsList[CurrentPotionIndex];
    }

    public void ToRight()
    {
        if (CurrentPotionIndex < potionsList.Count - 1)
            CurrentPotionIndex++;

    }

    public void ToLeft()
    {
        if (CurrentPotionIndex > 0)
            CurrentPotionIndex--;
    }
    
    public bool IsAtFirstPotion() => CurrentPotionIndex == 0;
    public bool IsAtLastPotion() => CurrentPotionIndex == potionsList.Count - 1;
    /*
    public bool HasIngredient(ItemData item)
    {
        return Inventory.instance.inventoryItems.Exists(slot => slot.itemData == item && slot.quantity > 0);
    }
}*/
}

