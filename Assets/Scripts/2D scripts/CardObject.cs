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
