using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEnemy2D : Enemy2D{
    private void Awake(){
        damage = 1;
        maxHP = 400;
        speed = 0.6f;
        currentHP = maxHP;
    }
}
