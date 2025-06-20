using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class WorldSceneManager : MonoBehaviour
{
    public static WorldSceneManager Instance;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        DynamicGI.UpdateEnvironment();
    }


    public void LoadScene(int sceneBuildIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneBuildIndex));
    }

    

    IEnumerator LoadSceneAsync(int sceneBuildIndex)
    {
        AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneBuildIndex);
        while (!op.isDone)
        {
            yield return null;
        }
        DynamicGI.UpdateEnvironment();
    }


    public void GameScene()
    {
        LoadScene(2);
    }

    public void MainMenu()
    {

        SceneManager.LoadScene(0);
    }


    public void WinGame()
    {
        SceneManager.LoadScene(3);
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }
    }
