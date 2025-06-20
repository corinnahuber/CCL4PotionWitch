using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BookUI : MonoBehaviour
{
    public static BookUI bookInstance = null;
    public TextMeshProUGUI potionName;
    public TextMeshProUGUI potionDescription;
    public Image potionImage;
    public TextMeshProUGUI potionTypeText;

    public List<InventorySlot> ingredientsList = new List<InventorySlot>();
    public GameObject[] ingredientImages;

    [SerializeField]
    Image[] tickImage;

    [SerializeField]
    Button brewButton;
    [SerializeField]
    Button leftButton;
    [SerializeField]
    Button rightButton;

    void Awake()
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


    //this method is called every frame to make sure the book is updated while its active not just when flipping pages!!
    //will see if we can call it somewhere else instead of Update() to avoid performance issues, but for now it works
    void Update()
    {
        if (BookToggle.bookToggleInstance.isOpen)
        {
            UpdatePotionDisplay();
            leftButton.interactable = !Book.bookInstance.IsAtFirstPotion();
            rightButton.interactable = !Book.bookInstance.IsAtLastPotion();
        }

    }


    private void UpdatePotionDisplay()
    {
        if (Book.bookInstance.potionsList.Count == 0)
        {
            return; // No potions to display
        }

        if (Book.bookInstance.AreAllIngredientsInInventory())
            brewButton.interactable = true; // Enable brew button if all ingredients are available
        else
            brewButton.interactable = false; // Disable brew button if not all ingredients are available

        PotionData currentPotion = Book.bookInstance.GetCurrentPotion();
        potionName.text = currentPotion.potionName;
        potionDescription.text = currentPotion.potionDescription;
        potionImage.sprite = currentPotion.potionImage;
        potionTypeText.text = currentPotion.potionType.ToString();

        UpdateBookIngredientsImages();
    }

    

    public void UpdateBookIngredientsImages()
    {
        PotionData currentPotion = Book.bookInstance.GetCurrentPotion();

        for (int i = 0; i < ingredientImages.Length; i++)
        {
            if (i < currentPotion.potionIngredients.Count)
            {
                ingredientImages[i].SetActive(true);
                ingredientImages[i].GetComponent<Image>().sprite = currentPotion.potionIngredients[i].itemImage;

                if (Inventory.instance.inventoryItems.Exists(slot => slot.itemData == currentPotion.potionIngredients[i] && slot.quantity > 0))
                    tickImage[i].enabled = true; // Show the tick image
                else
                    tickImage[i].enabled = false; // Hide the tick image
            }
            else
                ingredientImages[i].SetActive(false);
        }
    }
}

