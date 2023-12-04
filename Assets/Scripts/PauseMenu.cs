using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    public void Continue(){
        GameManager.isGameRun = true;
        gameObject.SetActive(false);
    }

    public void ExitMainMenu(){
        GameManager.isGameRun = false;
        SceneManager.LoadScene("MainMenu");
    }
}
