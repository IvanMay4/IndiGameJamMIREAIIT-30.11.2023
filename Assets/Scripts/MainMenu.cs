using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() 
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
    public void Level1()
    {
        SceneManager.LoadScene("GameLevel1");
    }
}
