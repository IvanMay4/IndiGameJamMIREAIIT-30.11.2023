using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceController : Controller{
    public GameObject bullet;

    private float attackTime;
    public float attackCooldown;
    public int damage;
    public bool isAttacking;
    private EnemyWave enemyWave;

    private void Start(){
        health = 200;
        enemyWave = FindAnyObjectByType<EnemyWave>();
    }

    private void Update(){
        if (enemyWave.GetCountEnemiesInLine(line) > 0 && isAttacking == false)
            if (enemyWave.FindFirstNoNullEnemy() != null)
                if (objectContainer.transform.position.x <= enemyWave.FindFirstNoNullEnemy().transform.position.x)
                    isAttacking = true;
        if (enemyWave.GetCountEnemiesInLine(line) == 0 && isAttacking == true)
            isAttacking = false;
        if (attackTime <= Time.time && isAttacking){
            GameObject bulletIntstance = Instantiate(bullet, transform);
            bulletIntstance.GetComponent<Bullet>().damage = damage;
            attackTime = Time.time + attackCooldown;
        }
    }
}
