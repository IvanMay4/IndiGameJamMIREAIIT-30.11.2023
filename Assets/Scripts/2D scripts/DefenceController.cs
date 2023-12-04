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
    public Animator animdef;

    private void Start()
    {
        animdef = GetComponent<Animator>();
        health = 200;
        enemyWave = FindAnyObjectByType<EnemyWave>();
    }

    private void Update(){
        if (!GameManager.isGameRun) return;
        if (enemyWave.GetCountEnemiesInLine(line) > 0 && isAttacking == false)
            if (enemyWave.FindFirstNoNullEnemy() != null)
                if (objectContainer.transform.position.x <= enemyWave.FindFirstNoNullEnemy().transform.position.x)
                    isAttacking = true;
        if (enemyWave.GetCountEnemiesInLine(line) == 0 && isAttacking == true)
            isAttacking = false;
        if (attackTime <= Time.time && isAttacking){
            animdef.SetTrigger("isAttacking");
            GameObject bulletIntstance = Instantiate(bullet, transform);
            GameManager.instance.background.PlayOneShot(GameManager.instance.paperBullet, 0.1f);
            bulletIntstance.GetComponent<Bullet>().damage = damage;
            attackTime = Time.time + attackCooldown;
        }
    }
}
