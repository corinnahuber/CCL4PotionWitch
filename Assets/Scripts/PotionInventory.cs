using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInventory : MonoBehaviour
{
    public static PotionInventory instance;
    public List<PotionData> potionsMade = new List<PotionData>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }



    public void AddPotion(PotionData potion)
    {
        potionsMade.Add(potion);
    }



    public void RemovePotion(PotionData potion)
    {
        potionsMade.Remove(potion);
    }
}



//come up with a way to display and track when you select a potion
//potion boxes can buttons that that when clicked they pass the potion data to the potion effects script
//and the bg color changes to indicate the selected potion
//button.backgroundColor = Color.green; // or any color to indicate selection