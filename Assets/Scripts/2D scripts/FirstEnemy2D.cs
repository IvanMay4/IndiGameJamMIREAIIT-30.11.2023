using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy2D : Enemy2D
{
    private void Awake(){
        damage = 1;
        maxHP = 200;
        speed = 0.35f;
        currentHP = maxHP;
        base.Awake();
    }
}
