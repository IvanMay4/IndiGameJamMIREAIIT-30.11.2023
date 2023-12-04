using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSave : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        if (GameManager.instance.isFirstCompleted)
        {
            OnStar();
        }
        else if (GameManager.instance.isSecondCompleted)
        {
            OnStar2();
        }
    }
    
    

    public void OnStar()
    {
        button.GetComponent<Button>().onClick.AddListener(PlayGame);
    }
    
    public void OnStar2()
    {
        button.GetComponent<Button>().onClick.AddListener(PlayGame);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 2");
    }
    
    public void PlayGame2()
    {
        SceneManager.LoadScene("Level 3");
    }
}
