using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEnemy2D : Enemy2D{
    private void Awake(){
        damage = 1;
        maxHP = 300;
        speed = 0.1f;
        currentHP = maxHP;
    }
}
