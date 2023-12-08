using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    private void Awake(){
        if (!PlayerPrefs.HasKey("MusicVolume"))
            PlayerPrefs.SetFloat("MusicVolume", 1f);
        Settings.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void PlayGame(){
        GameManager.isGameRun = true;
        SceneManager.LoadScene(PlayerPrefs.GetInt("IsSecondCompleted") == 1? "Level 3": PlayerPrefs.GetInt("IsFirstCompleted") == 1 ? "Level 2": "Level 1");
    }

    public void LoadSettings(){
        SceneManager.LoadScene("Settings");
    }

    public void BackButton(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
    public void Level1(){
        SceneManager.LoadScene("GameLevel1");
    }
    
    public void Level2(){
        SceneManager.LoadScene("GameLevel2");
    }
    
    public void Level3(){
        SceneManager.LoadScene("GameLevel3");
    }
}
