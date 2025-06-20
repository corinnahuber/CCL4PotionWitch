using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Dialog : MonoBehaviour
{
    public Animator animator;
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

    private bool isTalking = false;



    void Start()
    {
        dialogueCanvas.SetActive(false); // Hide the dialogue box initially
        animator.SetBool("Talking", false); // Ensure talking animation is off

    }

    private void OnMouseDown()
    {
        if (isTalking) return;
        
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < 5f)

        {   animator.SetBool("Talking", true); // Start talking animation
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
            animator.SetBool("Talking", false); // Stop talking animation
        }
    }
}