using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotionsInventoryUI : MonoBehaviour
{

    public static PotionsInventoryUI instance;

    public Image[] potionBackgroundImage;
    public Image[] potionImage;

    Color pickedColor = new Color(0.8f, 0.5f, 1f, 1f); // RGBA values for light purple

    public int selectedIndex = -1; // -1 means none selected

    public Button[] potionButtons; 

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        
        int count = potionButtons.Length;
        potionBackgroundImage = new Image[count];
        potionImage = new Image[count];


        for (int i = 0; i < count; i++)
        {
            int index = i; 
            potionButtons[i].onClick.AddListener(() => SelectedPotion(index));
            potionButtons[i].interactable = false; // Initially disable the button

            Image[] childImages = potionButtons[i].GetComponentsInChildren<Image>();
            potionBackgroundImage[i] = childImages[1];
            potionImage[i] = childImages[2];
            potionImage[i].enabled = false; // Initially hide the potion image
        }
    }

    public void PotionInventoryUIUpdate()
    {

        for (int i = 0; i < potionButtons.Length; i++)
        {
            if (i < PotionInventory.instance.potionsMade.Count)
            {
                PotionData potion = PotionInventory.instance.potionsMade[i];
                potionImage[i].enabled = true; // Show the potion image
                potionImage[i].sprite = potion.potionImage; // Assuming PotionData has a sprite field
                potionButtons[i].interactable = true; // Enable the button
            }
            else
            {
                potionImage[i].enabled = false; // Hide the potion image
                potionButtons[i].interactable = false; // Disable the button
                potionBackgroundImage[i].color = Color.gray; // Reset background color

            }
        }
    }


    public int SelectedPotion(int index)
    {
        // Deselect the previously selected button if any
        if (selectedIndex != -1 && selectedIndex != index)
        {
            potionBackgroundImage[selectedIndex].color = Color.gray;
        }
        //ex. if selectedIndex is 0 and index is 1, it will deselect the potion at index 0
        if (selectedIndex == index)
        {
            // Deselect if clicked again
            potionBackgroundImage[index].color = Color.gray;
            selectedIndex = -1;
        }
        else
        {
            // Select new one
            potionBackgroundImage[index].color = pickedColor;
            selectedIndex = index;
        }
        return selectedIndex;
        // Return the index of the selected potion that will be used to get the potion data when clicked on enemy!
    }

}