using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : Controller{
    int generatorPower;
    int generatorCooldown;
    int firstgeneratorCooldown;
    int time;
    private bool isFirst;

    void Awake(){
        health = 200;
        generatorPower = 50;
        generatorCooldown = 20 * 60;
        time = 0;
        firstgeneratorCooldown = 7 * 60;
        isFirst = true;
    }

    void FixedUpdate(){
        if (!GameManager.isGameRun) return;
        time++;
        if (isFirst){
            if (time >= firstgeneratorCooldown){
                anim.SetTrigger("isGenerating");
                GameManager.instance.generatorCoins += generatorPower;
                time = 0;
                isFirst = false;
            }
        }
        else if(time >= generatorCooldown){
            anim.SetTrigger("isGenerating");
            GameManager.instance.generatorCoins += generatorPower;
            time = 0;
        }
    }
}
