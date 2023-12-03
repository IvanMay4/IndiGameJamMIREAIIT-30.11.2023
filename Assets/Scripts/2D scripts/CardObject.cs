using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardObject : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {
    public GameObject object_drag;
    public GameObject object_game;
    public Canvas canvas;
    private GameObject objectDragInstance;
    private GameManager gameManager;
    [SerializeField] Image imageCooldown;
    [SerializeField] int cooldown;
    int time = 0;
    bool isCooldown = false;

    private void Start() {
        gameManager = GameManager.instance;
    }

    private void FixedUpdate() {
        if (!isCooldown) return;
        time--;
        imageCooldown.fillAmount = 1f / cooldown * time;
        if (time <= 0)
            isCooldown = false;
    }

    public void CoolwownActivate() {
        time = cooldown;
        imageCooldown.fillAmount = 1;
        isCooldown = true;
    }

    public bool IsCooldown() => isCooldown;

    public void OnDrag(PointerEventData eventData) {
        if (objectDragInstance == null) return;
        objectDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (object_drag.CompareTag("DefenceDrag"))
            if (gameManager.generatorCoins < gameManager.generatorCostDefence || gameManager.generatorCoins - gameManager.generatorCostGenerator < 0 || IsCooldown())
                return;
        if (object_drag.CompareTag("GeneratorDrag"))
            if (gameManager.generatorCoins < gameManager.generatorCostGenerator || gameManager.generatorCoins - gameManager.generatorCostGenerator < 0 || IsCooldown())
                return;

        objectDragInstance = Instantiate(object_drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        objectDragInstance.GetComponent<ObjectDragging>().card = this;

        gameManager.draggingObject = objectDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData){
        gameManager.PlaceObject();
        gameManager.draggingObject = null;
        Destroy(objectDragInstance);
    }
}
