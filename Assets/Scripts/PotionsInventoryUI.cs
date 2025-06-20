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
        int count = PotionInventory.instance.potionsMade.Count;

        if (count == 0)
        {
            // No potions left – reset selection and highlights
            if (selectedIndex != -1)
            {
                potionBackgroundImage[selectedIndex].color = Color.gray;
                selectedIndex = -1;
            }
        }
        else
        {
            // Auto-select the first potion only if none selected
            if (selectedIndex == -1 && count > 0)
            {
                selectedIndex = 0;
            }

            // Safety: if selectedIndex is now out of bounds (e.g. item was removed), reset it
            if (selectedIndex >= count)
            {
                selectedIndex = 0; // fallback to 0 or -1 if you want no selection
            }
        }
        
        for (int i = 0; i < potionButtons.Length; i++)
        {
            if (i < count)
            {
                PotionData potion = PotionInventory.instance.potionsMade[i];
                potionImage[i].enabled = true; // Show the potion image
                potionImage[i].sprite = potion.potionImage; // Assuming PotionData has a sprite field
                potionButtons[i].interactable = true; // Enable the button

                potionBackgroundImage[i].color =
                (i == selectedIndex) ? pickedColor : Color.gray;
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

        if (index == selectedIndex)
                return selectedIndex;   

        // reset previous highlight
        if (selectedIndex != -1)
            potionBackgroundImage[selectedIndex].color = Color.gray;

        // select new one
        selectedIndex = index;
        potionBackgroundImage[index].color = pickedColor;
        return selectedIndex;
    }

}