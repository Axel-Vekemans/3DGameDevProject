using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "LevelSelect";

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);

    }

    public void Exit()
    {
        Debug.Log("exiting...");
        Application.Quit();

    }
}
