using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Potion")]

public class PotionData : ScriptableObject
{

    //tyoe of potion from the enum
    public enum PotionType
    {
        Health,
        Damage,
        Destruction,
        Stun,
        Speed
    }
    public string potionName;
    public Sprite potionImage;

    [TextArea]
    public string potionDescription;
    public int PotionMaxStack = 3;

    //list containing the ingredients needed to craft the potion
    public List<ItemData> potionIngredients = new List<ItemData>();

    //type of potion
    public PotionType potionType;
}

