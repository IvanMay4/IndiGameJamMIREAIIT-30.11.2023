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
        health = 500;
        generatorPower = 25;
        generatorCooldown = 1 * 1200;
        time = 0;
        firstgeneratorCooldown = 1 * 420;
        isFirst = true;
    }

    void FixedUpdate(){
        time++;
        if (isFirst)
        {
            if (time >= firstgeneratorCooldown)
            {
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
