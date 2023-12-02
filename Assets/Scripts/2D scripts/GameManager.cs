using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;
    public TMP_Text textGeneratorCoins;

    public static GameManager instance;
    public int generatorCoins;

    private void Awake(){
        instance = this;
        generatorCoins = 100;
    }

    private void Update(){
        textGeneratorCoins.text = $"Ёнерги€:{generatorCoins}";
    }

    public void PlaceObject()
    {
        if (draggingObject != null && currentContainer != null)
        {
            GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
            objectGame.GetComponent<Controller>().mobs = currentContainer.GetComponent<ObjectContainer>().spawnPoint.mobs;
            currentContainer.GetComponent<ObjectContainer>().isFull = true;
        }
    }
}
