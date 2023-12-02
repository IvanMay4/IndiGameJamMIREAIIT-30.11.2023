using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour{
    [SerializeField] public int maxHP = 10;
    protected int currentHP = 0;
    [SerializeField] protected float speed = 1f;
    protected Vector3 move = new Vector3(0, 0, 0);
    private int time = 0;

    protected void Awake(){
        currentHP = maxHP;
    }

    protected void FixedUpdate(){
        Move();
        transform.position += move;
        time++;
        if (time >= 5 * 60)
            Destroy(gameObject);
    }

    protected void Move(){
        move.x = -speed;
    }
}
