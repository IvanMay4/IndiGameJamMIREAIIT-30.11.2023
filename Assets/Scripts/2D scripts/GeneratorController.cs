using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : Controller{
    int generatorPower;
    int generatorCooldown;
    int time;

    void Awake(){
        health = 10;
        generatorPower = 50;
        generatorCooldown = 1 * 60;
        time = 0;
    }

    void FixedUpdate(){
        time++;
        if(time >= generatorCooldown){
            GameManager.instance.generatorCoins += generatorPower;
            time = 0;
        }
    }
}
