using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{
    public List<GameObject> mobs;
    public int health;
    public static int generatorCost;

    public void ReceiveDamage(int damage){
        if (health - damage <= 0) Destroy(gameObject);
        else health -= damage;
    }
}
