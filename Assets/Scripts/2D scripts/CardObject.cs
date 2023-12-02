using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardObject : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_drag;
    public GameObject object_game;
    public Canvas canvas;
    private GameObject objectDragInstance;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        objectDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (object_game.TryGetComponent(out DefenceController _)){
            if (GameManager.instance.generatorCoins < DefenceController.generatorCost)
                return;
            GameManager.instance.generatorCoins -= DefenceController.generatorCost;
        }
        else if (object_game.TryGetComponent(out GeneratorController _)){
            if (GameManager.instance.generatorCoins < GeneratorController.generatorCost)
                return;
            GameManager.instance.generatorCoins -= GeneratorController.generatorCost;
        }

        objectDragInstance = Instantiate(object_drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        objectDragInstance.GetComponent<ObjectDragging>().card = this;

        GameManager.instance.draggingObject = objectDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        gameManager.PlaceObject();
        gameManager.draggingObject = null;
        Destroy(objectDragInstance);
    }
}
