using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEnemy2D : Enemy2D{
    private void Awake(){
        maxHP = 50;
        currentHP = maxHP;
    }
}
