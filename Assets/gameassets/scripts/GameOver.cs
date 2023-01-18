using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public string levelToLoad = "MainMenu";

    void Awake()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
        Wave_Spawner.EnemiesAlive = 0;

    }

    public void Menu()
    {
        Debug.Log("go to menu");
        SceneManager.LoadScene(levelToLoad);
    }
}
