using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEnemy2D : Enemy2D{
    private void Awake(){
        damage = 1;
        maxHP = 400;
        speed = 1f;
        currentHP = maxHP;
    }
    
    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == 8){
            StartCoroutine(Attack(collision));
            isStopped = true;
            if (isStopped)
            {
                StartCoroutine(AttackAnim(collision));
            }
        }
    }
    
    public IEnumerator AttackAnim(Collider2D collision)
    {
        if (collision == null) isStopped = false;
        else
        {
            yield return new WaitForSeconds(1);
            anim.SetTrigger("vihIsAttacking");
            StartCoroutine(AttackAnim(collision));
        }
    }
}
