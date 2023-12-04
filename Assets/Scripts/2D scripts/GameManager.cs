using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public GameObject draggingObject;
    public GameObject currentContainer;
    public TMP_Text textGeneratorCoins;
    public int generatorCostDefence = 100;
    public int generatorCostGenerator = 50;
    public int generatorCostTank = 75;
    public AudioSource background;
    public AudioClip placeDefence;
    public AudioClip paperDamage;
    public AudioClip paperBullet;
    public AudioClip raycoon;
    public AudioClip damageTrash;
    public AudioClip victorySound;
    public AudioClip defeatSound;
    public AudioClip kabanSound;
    public AudioClip vihuholSound;
    public bool isFirstCompleted;
    public bool isSecondCompleted;
    public bool isThirdCompleted;
    

    public static GameManager instance;
    public int generatorCoins;

    private void Awake(){
        instance = this;
        generatorCoins = 100;
        if (!PlayerPrefs.HasKey("IsFirstCompleted")) PlayerPrefs.SetInt("IsFirstCompleted", 0);
        if (!PlayerPrefs.HasKey("IsSecondCompleted")) PlayerPrefs.SetInt("IsSecondCompleted", 0);
        if (!PlayerPrefs.HasKey("IsThirdCompleted")) PlayerPrefs.SetInt("IsThirdCompleted", 0);
    }

    private void Start(){
        background = GetComponent<AudioSource>();
    }

    private void Update(){
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            textGeneratorCoins.text = $"{generatorCoins}";
        }
    }

    public void PlaceObject(){
        if (draggingObject != null && currentContainer != null){
            if (draggingObject.CompareTag("DefenceDrag")){
                instance.generatorCoins -= generatorCostDefence;
                draggingObject.GetComponent<ObjectDragging>().card.CoolwownActivate();
            }
            else if (draggingObject.CompareTag("GeneratorDrag")){
                instance.generatorCoins -= generatorCostGenerator;
                draggingObject.GetComponent<ObjectDragging>().card.CoolwownActivate();
            }
            else if (draggingObject.CompareTag("TankDrag")){
                instance.generatorCoins -= generatorCostTank;
                draggingObject.GetComponent<ObjectDragging>().card.CoolwownActivate();
            }
            GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isFull = true;
            objectGame.GetComponent<Controller>().objectContainer = currentContainer.GetComponent<ObjectContainer>();
            objectGame.GetComponent<Controller>().line = currentContainer.GetComponent<ObjectContainer>().line;
            background.PlayOneShot(placeDefence, 0.1f);
        }
    }
}
