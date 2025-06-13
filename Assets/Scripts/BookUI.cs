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


    void Start()
    {
        bookInstance = this;
        leftButton.interactable = false;

        PotionData currentPotion = Book.bookInstance.GetCurrentPotion();
        potionName.text = currentPotion.potionName;
        potionDescription.text = currentPotion.potionDescription;
        potionImage.sprite = currentPotion.potionImage;
        potionTypeText.text = currentPotion.potionType.ToString();

        if (Book.bookInstance.CurrentPotionIndex == 0)
        {
            leftButton.interactable = false; // Disable left button if at the first potion
            rightButton.interactable = true;
        }
        UpdateBookIngredientsImages();
    }



    //this method is called every frame to make sure the book is updated while its active not just when flipping pages!!
    //will see if we can call it somewhere else instead of Update() to avoid performance issues, but for now it works
    void Update()
    {
        if (gameObject.activeSelf)
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
                {
                    Debug.Log($"Ingredient {currentPotion.potionIngredients[i].itemName} is available in inventory.");
                    tickImage[i].enabled = true; // Show the tick image
                }
                else
                {
                    Debug.Log($"Code is checking for: {currentPotion.potionIngredients[i].itemName}");
                    tickImage[i].enabled = false; // Hide the tick image
                }
            }
            else
                ingredientImages[i].SetActive(false);
        }
    }
}


/*
public class BookUI : MonoBehaviour
{
    public static BookUI bookInstance = null;

    public TextMeshProUGUI potionName;
    public TextMeshProUGUI potionDescription;
    public Image potionImage;

    public TextMeshProUGUI potionTypeText;

    [SerializeField]
    //List<PotionData> potionsList = new List<PotionData>();

    [SerializeField]
    public List<InventorySlot> ingredientsList = new List<InventorySlot>();

    [SerializeField]
    public GameObject[] ingredientImages; // Assuming you have a way to display ingredient images

    [SerializeField]
    Image[] tickImage; // Assuming you have a way to display tick images for available ingredients

    [SerializeField]
    Button brewButton;
    [SerializeField]
    Button leftButton;
    [SerializeField]
    Button rightButton;
    int currentPotionIndex = 0;  //making sure we start with the first potion


    void Start()
    {
        bookInstance = this;
        // brewButton.interactable = false; // Initially disable the brew button
        leftButton.interactable = false;

        PotionData currentPotion = potionsList[currentPotionIndex];
        potionName.text = currentPotion.potionName;
        potionDescription.text = currentPotion.potionDescription;
        potionImage.sprite = currentPotion.potionImage;
        potionTypeText.text = currentPotion.potionType.ToString();

        if (currentPotionIndex == 0)
        {
            leftButton.interactable = false; // Disable left button if at the first potion
            rightButton.interactable = true;
        }

        UpdateBookIngredientsImages();
    }



    //this method is called every frame to make sure the book is updated while its active not just when flipping pages!!
    void Update()
    {
        if (gameObject.activeSelf)
        {
            UpdatePotionDisplay();
        }
    }

    public void ToLeft()
    {
        if (potionsList.Count != 0)
        {
            if (currentPotionIndex > 0)
            {
                currentPotionIndex--;
                rightButton.interactable = true;
            }
            else
                leftButton.interactable = false;
        }

    }

    public void ToRight()
    {
        if (potionsList.Count != 0)
        {
            if (currentPotionIndex < potionsList.Count - 1)
            {
                currentPotionIndex++;
                leftButton.interactable = true;
            }
            else
                rightButton.interactable = false;
        }
    }


    private void UpdatePotionDisplay()
    {
        if (potionsList.Count == 0)
        {
            return; // No potions to display
        }

        PotionData currentPotion = potionsList[currentPotionIndex];
        potionName.text = currentPotion.potionName;
        potionDescription.text = currentPotion.potionDescription;
        potionImage.sprite = currentPotion.potionImage;
        potionTypeText.text = currentPotion.potionType.ToString();

        UpdateBookIngredientsImages();
    }



    //needs to make sure that the ticked images are updated when the ingredients are collected!
    public void UpdateBookIngredientsImages()
    {
        PotionData currentPotion = potionsList[currentPotionIndex];


        for (int i = 0; i < ingredientImages.Length; i++)
        {
            if (i < currentPotion.potionIngredients.Count)
            {
                ingredientImages[i].SetActive(true);
                ingredientImages[i].GetComponent<Image>().sprite = currentPotion.potionIngredients[i].itemImage;


                //if the .potionsingredients mentioned are in the inventory > 0 quantity then show the tick image
                if (Inventory.instance.inventoryItems.Exists(slot => slot.itemData == currentPotion.potionIngredients[i] && slot.quantity > 0))
                {
                    Debug.Log($"Ingredient {currentPotion.potionIngredients[i].itemName} is available in inventory.");
                    tickImage[i].enabled = true; // Show the tick image
                }
                else
                {
                    Debug.Log($"Ingredient {currentPotion.potionIngredients[i].itemName} is NOT available in inventory.");
                    Debug.Log($"Code is checking for: {currentPotion.potionIngredients[i].itemName}");
                    tickImage[i].enabled = false; // Hide the tick image
                }
            }
            else
            {
                ingredientImages[i].SetActive(false);
            }
        }
    }
}

*/
