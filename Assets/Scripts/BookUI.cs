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

    [SerializeField]
    List<PotionData> potionsList = new List<PotionData>();

    [SerializeField]
    List<ItemData> ingredientsList = new List<ItemData>();

    [SerializeField]
    GameObject[] ingredientImages; // Assuming you have a way to display ingredient images


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
        brewButton.interactable = false; // Initially disable the brew button
        leftButton.interactable = false; 

        PotionData currentPotion = potionsList[currentPotionIndex];
        potionName.text = currentPotion.potionName;
        potionDescription.text = currentPotion.potionDescription;
        potionImage.sprite = currentPotion.potionImage;
        potionTypeText.text = currentPotion.potionType.ToString();

    }

    public void ToLeft()
    {
        if (potionsList.Count != 0)
        {
            if (currentPotionIndex > 0)
            {
                currentPotionIndex--;
                UpdatePotionDisplay();
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
                UpdatePotionDisplay();
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
            potionName.text = "No Potions Available";
            potionDescription.text = "";
            potionImage.sprite = null;
            potionTypeText.text = "";
            brewButton.interactable = false; // Disable brew button if no potions
            return;
        }

        PotionData currentPotion = potionsList[currentPotionIndex];
        potionName.text = currentPotion.potionName;
        potionDescription.text = currentPotion.potionDescription;
        potionImage.sprite = currentPotion.potionImage;
        potionTypeText.text = currentPotion.potionType.ToString();

        //for the images of the ingredients
        for (int i = 0; i < ingredientsList.Count; i++)
        {
            if (i < currentPotion.potionIngredients.Count)
            {
                ItemData ingredient = currentPotion.potionIngredients[i];
                // Assuming you have a method to display the ingredient image
                //DisplayIngredientImage(ingredient, i);
            }
        }
    }
}



