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
    string[][] enemiesWaves;
    private int[][] cooldowns;
    private int[][] lines;
    private int time;
    public Enemy2D[] enemies;
    [SerializeField] FirstEnemy2D firstEnemy2DPrefab;
    [SerializeField] SecondEnemy2D secondEnemy2DPrefab;
    [SerializeField] ThirdEnemy2D thirdEnemy2DPrefab;
    string firstEnemy2DName = "FirstEnemy2D";
    string secondEnemy2DName = "SecondEnemy2D";
    string thirdEnemy2DName = "ThirdEnemy2D";

    void Start(){
        countWaves = 4;
        currentWaves = 0;
        currentEnemySpawn = 0;
        enemiesWaves = new string[4][];
        enemiesWaves[0] = new string[]{firstEnemy2DName, secondEnemy2DName, thirdEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName};
        enemiesWaves[1] = new string[]{firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName};
        enemiesWaves[2] = new string[]{secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName};
        enemiesWaves[3] = new string[]{thirdEnemy2DName, thirdEnemy2DName};
        cooldowns = new int[4][];
        cooldowns[0] = new int[]{2 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[1] = new int[]{2 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[2] = new int[]{1 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[3] = new int[]{2 * 60};
        lines = new int[4][];
        lines[0] = new int[]{1, 2, 3, 3, 2, 1};
        lines[1] = new int[]{5, 4, 3, 2, 1, 1};
        lines[2] = new int[]{1, 3, 5, 4, 2};
        lines[3] = new int[]{2, 4};
    }

    void FixedUpdate(){
        time++;
        if(enemies.Length == 0 && currentWaves < countWaves){
            currentWaves++;
            time = 0;
            enemies = new Enemy2D[enemiesWaves[currentWaves - 1].Length];
            enemies[0] = Instantiate(GetEnemyPrefab(enemiesWaves[currentWaves - 1][0]), GetEnemyPosition(lines[currentWaves - 1][0]), new Quaternion());
            if (enemiesWaves[currentWaves - 1][0] == firstEnemy2DName)
            {
                GameManager.instance.background.PlayOneShot(GameManager.instance.raycoon, 0.1f);
            }
            enemies[0].transform.SetParent(gameObject.transform, false);
            enemies[0].line = lines[currentWaves - 1][0];
            currentEnemySpawn = 1;
        }
        if (currentEnemySpawn >= enemiesWaves[currentWaves - 1].Length){
            DeleteNullEnemies();
            return;
        }
        if(time == cooldowns[currentWaves - 1][currentEnemySpawn - 1]){
            enemies[currentEnemySpawn] = Instantiate(GetEnemyPrefab(enemiesWaves[currentWaves - 1][currentEnemySpawn]), GetEnemyPosition(lines[currentWaves - 1][currentEnemySpawn]), new Quaternion());
            if (enemiesWaves[currentWaves - 1][currentEnemySpawn] == firstEnemy2DName)
            {
                GameManager.instance.background.PlayOneShot(GameManager.instance.raycoon, 0.1f);
            }
            if (enemiesWaves[currentWaves - 1][currentEnemySpawn] == secondEnemy2DName)
            {
                GameManager.instance.background.PlayOneShot(GameManager.instance.kabanSound, 0.1f);
            }
            if (enemiesWaves[currentWaves - 1][currentEnemySpawn] == thirdEnemy2DName)
            {
                GameManager.instance.background.PlayOneShot(GameManager.instance.vihuholSound, 0.1f);
            }
            enemies[currentEnemySpawn].transform.SetParent(gameObject.transform, false);
            enemies[currentEnemySpawn].line = lines[currentWaves - 1][currentEnemySpawn];
            currentEnemySpawn++;
            time = 0;
        }
    }

    public int GetCountEnemiesInLine(int line){
        int count = 0;
        foreach (Enemy2D enemy in enemies)
            if(enemy != null)
                if (enemy.line == line)
                    count++;
        return count;
    }

    private void DeleteNullEnemies(){
        for(int i = 0;i < enemies.Length;i++)
            if (enemies[i] == null){
                ArrayUtility.Remove(ref enemies, enemies[i]);
                i--;
            }
    }

    public Enemy2D FindFirstNoNullEnemy(){
        for (int i = 0; i < enemies.Length; i++)
            if (enemies[i] != null)
                return enemies[i];
        return null;
    }

    private Enemy2D GetEnemyPrefab(string enemy){
        if (enemy == firstEnemy2DName) return firstEnemy2DPrefab;
        if (enemy == secondEnemy2DName) return secondEnemy2DPrefab;
        if (enemy == thirdEnemy2DName) return thirdEnemy2DPrefab;
        return null;
    }

    private Vector3 GetEnemyPosition(int line){
        if (line == 1) return new Vector3(903, 357, 0);
        if (line == 2) return new Vector3(903, 165, 0);
        if (line == 3) return new Vector3(903, -35, 0);
        if (line == 4) return new Vector3(903, -212, 0);
        if (line == 5) return new Vector3(903, -385, 0);
        return new Vector3();
    }
}
