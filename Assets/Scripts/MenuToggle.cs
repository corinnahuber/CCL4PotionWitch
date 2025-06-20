using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public GameObject instructionsPanel;
    private bool isOpen = false;


    
    public void Instructions()
    {
        if (instructionsPanel != null)
        {
            isOpen = !isOpen;
            instructionsPanel.SetActive(isOpen);
        }
    }
}
