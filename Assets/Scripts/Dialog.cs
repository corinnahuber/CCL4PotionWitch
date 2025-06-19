using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Dialog : MonoBehaviour
{
    public PlayerMovement player; // Reference to the PlayerMovement script
    [SerializeField]
    GameObject potionInventory; // Reference to the potion inventory item
    [SerializeField]
    TextMeshProUGUI dialogueText;
    [SerializeField]
    GameObject dialogueCanvas; // UI panel at bottom of screen

    [SerializeField]
    public Button nextButton; // Button to show next line

    [SerializeField]
    [TextArea(3, 10)]
    string[] dialogueLines;
    private int currentLineIndex = 0;




    void Start()
    {
        dialogueCanvas.SetActive(false); // Hide the dialogue box initially

    }

    private void OnMouseDown()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < 5f)
        {
            dialogueCanvas.SetActive(true);
            potionInventory.SetActive(false);
            player.enabled = false;
            StartDialogue(dialogueLines);
        }
    }

    public void StartDialogue(string[] lines)
    {
        dialogueLines = lines;
        currentLineIndex = 0;
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            dialogueCanvas.SetActive(false);
            potionInventory.SetActive(true);
            player.enabled = true; 
        }
    }
}