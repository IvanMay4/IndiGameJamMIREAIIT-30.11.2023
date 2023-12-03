using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour{
    public int maxHP = 10;
    protected int currentHP = 0;
    protected float speed = 1f;
    public int damage;
    public bool isStopped;
    public float damageCooldown;
    public int line;
    protected Vector3 move = new Vector3(0, 0, 0);

    protected void Awake(){
        currentHP = maxHP;
        damage = 2;
    }

    protected void FixedUpdate(){
        move = new Vector3(0, 0, 0);
        Move();
        transform.position += move;
        if (transform.position.x <= 0)
        {
            GameManager.instance.background.PlayOneShot(GameManager.instance.victorySound,0.1f);
            Settings.OpenGameOver();
        }
    }

    protected void Move(){
        if (isStopped)return;
        move.x = -speed;
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == 8){
            StartCoroutine(Attack(collision));
            isStopped = true;
        }
    }

    IEnumerator Attack(Collider2D collision){
        if (collision == null) isStopped = false;
        else{
            collision.gameObject.GetComponent<Controller>().ReceiveDamage(damage);
            yield return new WaitForSeconds(damageCooldown);
            GameManager.instance.background.PlayOneShot(GameManager.instance.damageTrash, 0.1f);
            StartCoroutine(Attack(collision));
        }
    }

    public void ReceiveDamage(int damage){
        if (currentHP - damage <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.background.PlayOneShot(GameManager.instance.paperDamage, 0.2f);
        }
        
        else
        {
            currentHP -= damage;
            GameManager.instance.background.PlayOneShot(GameManager.instance.paperDamage, 0.2f);
        }
    }
}
