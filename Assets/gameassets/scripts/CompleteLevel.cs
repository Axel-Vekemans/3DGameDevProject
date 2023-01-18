    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{

    public string levelToLoad = "MainMenu";


    public void Continue()
    {
        Debug.Log("go to menu");
        SceneManager.LoadScene(levelToLoad);
    }

    
}
