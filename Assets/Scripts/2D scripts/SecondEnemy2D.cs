using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemy2D : Enemy2D{
    private void Awake(){
        damage = 1;
        maxHP = 5;
        speed = 2f;
        currentHP = maxHP;
        base.Awake();
    }
}
