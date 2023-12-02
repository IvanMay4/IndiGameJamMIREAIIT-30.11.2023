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

    private void Awake(){
        generatorCost = 100;
    }

    private void Update()
    {
        if (mobs.Count > 0 && isAttacking == false && transform.position.x <= mobs[0].transform.position.x)
        {
            isAttacking = true;
        }
        else if (mobs.Count == 0 && isAttacking == true)
        {
            isAttacking = false;
        }
        
        if (attackTime <= Time.time && mobs.Count > 0)
        {
            GameObject bulletIntstance = Instantiate(bullet, transform);
            bulletIntstance.GetComponent<Bullet>().damage = damage;
            attackTime = Time.time + attackCooldown;
        }
    }
}
