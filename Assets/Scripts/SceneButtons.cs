using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneButtonHandler : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject PauseMenuUI;

    
    void Start()
    {
        if (PauseMenuUI != null)
        {
            PauseMenuUI.SetActive(false); // Ensure the pause menu is initially hidden
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }


    public void ResumeGame()
    {
        isPaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }


    public void ExitGame()
    {
        //WorldSceneManager.Instance.ExitGame();
    }

    public void MainMenu()
    {
        //WorldSceneManager.Instance.MainMenu();
    }

    public void RestartGame()
    {
        //WorldSceneManager.Instance.GameScene();
    }

     public void TogglePause()
{
    isPaused = !isPaused;
    Debug.Log("Toggling pause, isPaused = " + isPaused);
    
    if (PauseMenuUI != null)
    {
        PauseMenuUI.SetActive(isPaused);
        Debug.Log("PauseMenuUI set active: " + isPaused);
    }
    else
    {
        Debug.LogWarning("PauseMenuUI is not assigned!");
    }

    Time.timeScale = isPaused ? 0 : 1;
    Debug.Log("Time.timeScale set to: " + Time.timeScale);
}
}


