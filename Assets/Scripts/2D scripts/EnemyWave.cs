using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyWave : MonoBehaviour{
    private int countWaves;
    private int currentWaves;
    private int currentEnemySpawn;
    Enemy2D[][] enemiesWaves;
    private int[][] cooldowns;
    private int time;
    public Enemy2D[] enemies;
    [SerializeField] FirstEnemy2D firstEnemy2DPrefab;
    [SerializeField] SecondEnemy2D secondEnemy2DPrefab;

    void Start(){
        countWaves = 4;
        currentWaves = 0;
        currentEnemySpawn = 0;
        enemiesWaves = new Enemy2D[4][];
        enemiesWaves[0] = new Enemy2D[]{new FirstEnemy2D(), new SecondEnemy2D()};
        enemiesWaves[1] = new Enemy2D[]{new FirstEnemy2D(), new FirstEnemy2D(), new FirstEnemy2D(), new FirstEnemy2D()};
        enemiesWaves[2] = new Enemy2D[]{new SecondEnemy2D(), new SecondEnemy2D(), new SecondEnemy2D()};
        enemiesWaves[3] = new Enemy2D[]{new FirstEnemy2D(), new SecondEnemy2D(), new SecondEnemy2D(), new FirstEnemy2D()};
        cooldowns = new int[4][];
        cooldowns[0] = new int[]{2 * 60};
        cooldowns[1] = new int[]{2 * 60, 1 * 60, 1 * 60};
        cooldowns[2] = new int[]{1 * 60, 1 * 60};
        cooldowns[3] = new int[]{2 * 60, 1 * 60, 1 * 60};
    }

    void FixedUpdate(){
        time++;
        if(enemies.Length == 0 && currentWaves < countWaves){
            currentWaves++;
            time = 0;
            enemies = new Enemy2D[enemiesWaves[currentWaves - 1].Length];
            enemies[0] = Instantiate(GetEnemyPrefab(enemiesWaves[currentWaves - 1][0]), new Vector3(850, 300, 0), new Quaternion());
            currentEnemySpawn = 1;
        }
        if (currentEnemySpawn >= enemiesWaves[currentWaves - 1].Length){
            DeleteNullEnemies();
            return;
        }
        if(time == cooldowns[countWaves - 1][currentEnemySpawn - 1]){
            enemies[currentEnemySpawn] = Instantiate(GetEnemyPrefab(enemiesWaves[currentWaves - 1][currentEnemySpawn]), new Vector3(850, 300, 0), new Quaternion());
            currentEnemySpawn++;
            time = 0;
        }
    }

    private void DeleteNullEnemies(){
        int i = 0;
        while(i < enemies.Length) { 
            if (enemies[i] == null){
                for (int j = i; j < enemies.Length - 1; j++)
                    enemies[j] = enemies[j + 1];
                ArrayUtility.Remove(ref enemies, enemies[enemies.Length - 1]);
                i--;
            }
            i++;
        }
    }

    private Enemy2D GetEnemyPrefab(Enemy2D enemy){
        if (enemy.GetType().Name == "FirstEnemy2D") return firstEnemy2DPrefab;
        if (enemy.GetType().Name == "SecondEnemy2D") return secondEnemy2DPrefab;
        return null;
    }
}
