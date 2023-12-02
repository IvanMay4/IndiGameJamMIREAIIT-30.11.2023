using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceContoller : MonoBehaviour
{
    public List<GameObject> mobs;
    public GameObject bullet;
    public GameObject toAttack;
    private float attackTime;
    public float attackCooldown;
    public int damage;
    public bool isAttacking;
    public int health;

    private void Update()
    {
        if (mobs.Count > 0 && isAttacking == false)
        {
            isAttacking = true;
            GameObject mobInstance = mobs[0];
            toAttack = mobInstance;
        }
        else if (mobs.Count == 0 && isAttacking == true)
        {
            isAttacking = false;
        }

        if (toAttack != null)
        {
            if (attackTime <= Time.time)
            {
                GameObject bulletIntstance = Instantiate(bullet, transform);
                bulletIntstance.GetComponent<Bullet>().damage = damage;
                attackTime = Time.time + attackCooldown;
            }
        }
    }
    
    public void ReceiveDamage(int Damage)
    {
        if (health - Damage <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            health = health - Damage;
        }
    }

}
