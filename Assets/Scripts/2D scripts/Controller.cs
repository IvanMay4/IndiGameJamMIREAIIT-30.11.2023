using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{
    public ObjectContainer objectContainer;
    public int health;
    public int line;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ReceiveDamage(int damage){
        if (health - damage <= 0) {
            objectContainer.isFull = false;
            Destroy(gameObject);
        }
        else
        {
            health -= damage;
        }
    }
}
