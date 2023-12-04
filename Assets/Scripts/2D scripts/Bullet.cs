using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public float movementSpeed;
    public int damage;
    
    void Update(){
        if (!GameManager.isGameRun) return;
        transform.Translate(new Vector3(0 , movementSpeed, 0));
    }
    
    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == 9){
            collision.gameObject.GetComponent<Enemy2D>().ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }
}
