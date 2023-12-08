using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour{
    public int maxHP = 10;
    protected int currentHP = 0;
    protected float speed = 1f;
    public int damage;
    public bool isStopped = false;
    public bool isAttack = false;
    public float damageCooldown;
    public int line;
    protected Vector3 move = new Vector3(0, 0, 0);
    public Animator anim;

    protected void Awake(){
        currentHP = maxHP;
        damage = 2;
    }

    private void Start(){
        anim = GetComponent<Animator>();
    }

    protected void FixedUpdate(){
        move = new Vector3(0, 0, 0);
        Move();
        transform.position += move;
        if (transform.position.x <= 0){
            GameManager.instance.background.PlayOneShot(GameManager.instance.defeatSound, Settings.volume);
            Settings.OpenGameOver();
        }
    }

    protected void Move(){
        if (isStopped || !GameManager.isGameRun) return;
        move.x = -speed;
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == 8){
            isAttack = true;
            StartCoroutine(Attack(collision));
            isStopped = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.layer == 8){
            isStopped = true;
            isAttack = true;
        }
    }

    public IEnumerator Attack(Collider2D collision){
        if (collision == null){
            isStopped = false;
            isAttack = false;
        }
        if (!isAttack && collision != null){
            yield return new WaitForSeconds(1);
            StartCoroutine(Attack(collision));
        }
        else if(collision != null){
            if (GameManager.isGameRun){
                collision.gameObject.GetComponent<Controller>().ReceiveDamage(damage);
                GameManager.instance.background.PlayOneShot(GameManager.instance.damageTrash, Settings.volume);
            }
            yield return new WaitForSeconds(damageCooldown);
            StartCoroutine(Attack(collision));
        }
    }
    

    public void ReceiveDamage(int damage){
        if (currentHP - damage <= 0){
            Destroy(gameObject);
            GameManager.instance.background.PlayOneShot(GameManager.instance.paperDamage, Settings.volume);
        }
        else{
            currentHP -= damage;
            GameManager.instance.background.PlayOneShot(GameManager.instance.paperDamage, Settings.volume);
        }
    }
}
