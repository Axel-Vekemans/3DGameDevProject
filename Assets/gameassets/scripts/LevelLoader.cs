using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public string mainLevel = "MainLevel";
    public string longLevel = "LongLevel";


    public void LoadLevel1()
    {
        SceneManager.LoadScene(mainLevel);

    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(longLevel);

    }
}
