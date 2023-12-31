using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] TMP_Text textWaves;
    string firstEnemy2DName = "FirstEnemy2D";
    string secondEnemy2DName = "SecondEnemy2D";
    string thirdEnemy2DName = "ThirdEnemy2D";

    public static EnemyWave en2D;

    void Start()
    {
        currentWaves = 0;
        currentEnemySpawn = 0;
        if (SceneManager.GetActiveScene().name == "GameLevel1") GameLevel1Scene();
        if (SceneManager.GetActiveScene().name == "GameLevel2") GameLevel2Scene();
        if (SceneManager.GetActiveScene().name == "GameLevel3") GameLevel3Scene();
    }

    private void GameLevel1Scene(){
        countWaves = 4;
        enemiesWaves = new string[countWaves][];
        enemiesWaves[0] = new string[]{firstEnemy2DName, secondEnemy2DName, thirdEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName};
        enemiesWaves[1] = new string[]{firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName};
        enemiesWaves[2] = new string[]{secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName};
        enemiesWaves[3] = new string[]{thirdEnemy2DName, thirdEnemy2DName};
        cooldowns = new int[countWaves][];
        cooldowns[0] = new int[]{10 * 60, 20 * 60, 20 * 60, 20 * 60, 1 * 60, 1 * 60};
        cooldowns[1] = new int[]{3 * 60, 2 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[2] = new int[]{3 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[3] = new int[]{3 * 60, 2 * 60};
        lines = new int[countWaves][];
        lines[0] = new int[]{1, 2, 3, 3, 2, 1};
        lines[1] = new int[]{5, 4, 3, 2, 1, 1};
        lines[2] = new int[]{1, 3, 5, 4, 2};
        lines[3] = new int[]{2, 4};
    }

    private void GameLevel2Scene()
    {
        countWaves = 5;
        enemiesWaves = new string[countWaves][];
        enemiesWaves[0] = new string[] { firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, firstEnemy2DName };
        enemiesWaves[1] = new string[] { secondEnemy2DName, secondEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, secondEnemy2DName, firstEnemy2DName };
        enemiesWaves[2] = new string[] { secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, secondEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, thirdEnemy2DName };
        enemiesWaves[3] = new string[] { thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, thirdEnemy2DName };
        enemiesWaves[4] = new string[] { firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, secondEnemy2DName, secondEnemy2DName, firstEnemy2DName, firstEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, secondEnemy2DName, secondEnemy2DName, firstEnemy2DName };
        cooldowns = new int[countWaves][];
        cooldowns[0] = new int[] { 10 * 60, 15 * 60, 15 * 60, 10 * 60, 5 * 60, 10 * 60, 5 * 60, 15 * 60, 3 * 60, 2 * 60 };
        cooldowns[1] = new int[] { 5 * 60, 3 * 60, 7 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 9 * 60, 5 * 60, 1 * 60, 1 * 60 };
        cooldowns[2] = new int[] { 5 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 3 * 60, 7 * 60, 2 * 60, 2 * 60 };
        cooldowns[3] = new int[] { 5 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 8 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 3 * 60 };
        cooldowns[4] = new int[] { 5 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 3 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60 };
        lines = new int[countWaves][];
        lines[0] = new int[] { 2, 3, 2, 4, 1, 3, 5, 1, 5, 2 };
        lines[1] = new int[] { 1, 2, 1, 1, 2, 2, 3, 1, 4, 4, 5, 5, 3 };
        lines[2] = new int[] { 5, 4, 3, 4, 2, 1, 2, 3, 4, 5 };
        lines[3] = new int[] { 1, 2, 3, 2, 1, 2, 3, 4, 2, 3, 4, 5, 4, 5, 3, 2 };
        lines[4] = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 3, 5, 5, 4, 5, 4, 3, 2, 1, 2, 3, 4, 5, 1, 3, 1, 2, 1, 2, 3, 4 };
    }

    private void GameLevel3Scene(){
        countWaves = 8;
        enemiesWaves = new string[countWaves][];
        enemiesWaves[0] = new string[]{firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName};
        enemiesWaves[1] = new string[]{secondEnemy2DName, thirdEnemy2DName, secondEnemy2DName, thirdEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName};
        enemiesWaves[2] = new string[]{firstEnemy2DName, secondEnemy2DName, thirdEnemy2DName};
        enemiesWaves[3] = new string[]{firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, firstEnemy2DName, secondEnemy2DName, firstEnemy2DName, thirdEnemy2DName};
        enemiesWaves[4] = new string[]{firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName};
        enemiesWaves[5] = new string[]{secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName};
        enemiesWaves[6] = new string[]{thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName};
        enemiesWaves[7] = new string[]{firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, firstEnemy2DName, firstEnemy2DName, firstEnemy2DName, secondEnemy2DName, secondEnemy2DName, secondEnemy2DName, thirdEnemy2DName, thirdEnemy2DName, thirdEnemy2DName};
        cooldowns = new int[countWaves][];
        cooldowns[0] = new int[]{10 * 60, 20 * 60, 1 * 60, 20 * 60, 1 * 60, 1 * 60, 10 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[1] = new int[]{8 * 60, 2 * 60, 8 * 60, 1 * 60, 8 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[2] = new int[]{5 * 60, 1 * 60, 1 * 60};
        cooldowns[3] = new int[]{5 * 60, 1 * 60, 2 * 60, 5 * 60, 2 * 60, 1 * 60, 5 * 60, 1 * 60, 2 * 60, 1 * 60};
        cooldowns[4] = new int[]{1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[5] = new int[]{1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[6] = new int[]{1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60};
        cooldowns[7] = new int[]{1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60, 1 * 60};
        lines = new int[countWaves][];
        lines[0] = new int[]{1, 4, 5, 2, 3, 1, 1, 2, 4, 5};
        lines[1] = new int[]{3, 1, 5, 4, 1, 1, 2, 2};
        lines[2] = new int[]{1, 1, 1};
        lines[3] = new int[]{1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
        lines[4] = new int[]{1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5};
        lines[5] = new int[]{1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5};
        lines[6] = new int[]{1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5};
        lines[7] = new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5};
    }

    void FixedUpdate(){
        if (currentWaves == countWaves && enemies.Length == 0 && SceneManager.GetActiveScene().name == "GameLevel1"){
            PlayerPrefs.SetInt("IsFirstCompleted", 1);
            SceneManager.LoadScene("Level 2");
            GameManager.instance.isFirstCompleted = true;
        }
        else if (currentWaves == countWaves && enemies.Length == 0 && SceneManager.GetActiveScene().name == "GameLevel2"){
            PlayerPrefs.SetInt("IsSecondCompleted", 1);
            SceneManager.LoadScene("Level 3");
            GameManager.instance.isSecondCompleted = true;
        }
        else if(currentWaves == countWaves && enemies.Length == 0 && SceneManager.GetActiveScene().name == "GameLevel3"){
            PlayerPrefs.SetInt("IsThirdCompleted", 1);
            SceneManager.LoadScene("Win");
            GameManager.instance.isThirdCompleted = true;
        }
        if (!GameManager.isGameRun) return;
        time++;
        if(enemies.Length == 0 && currentWaves < countWaves){
            currentWaves++;
            time = 0;
            enemies = new Enemy2D[enemiesWaves[currentWaves - 1].Length];
            currentEnemySpawn = 0;
            if (currentWaves < countWaves) textWaves.text = "Next Wave";
            else textWaves.text = "Final Wave";
        }
        if (currentEnemySpawn >= enemiesWaves[currentWaves - 1].Length){
            DeleteNullEnemies();
            return;
        }
        if(time == cooldowns[currentWaves - 1][currentEnemySpawn]){
            enemies[currentEnemySpawn] = Instantiate(GetEnemyPrefab(enemiesWaves[currentWaves - 1][currentEnemySpawn]), GetEnemyPosition(lines[currentWaves - 1][currentEnemySpawn]), new Quaternion());
            if (enemiesWaves[currentWaves - 1][currentEnemySpawn] == firstEnemy2DName){
                GameManager.instance.background.PlayOneShot(GameManager.instance.raycoon, Settings.volume);
            }
            if (enemiesWaves[currentWaves - 1][currentEnemySpawn] == secondEnemy2DName){
                GameManager.instance.background.PlayOneShot(GameManager.instance.kabanSound, Settings.volume);
            }
            if (enemiesWaves[currentWaves - 1][currentEnemySpawn] == thirdEnemy2DName){
                GameManager.instance.background.PlayOneShot(GameManager.instance.vihuholSound, Settings.volume);
            }
            enemies[currentEnemySpawn].transform.SetParent(gameObject.transform, false);
            enemies[currentEnemySpawn].line = lines[currentWaves - 1][currentEnemySpawn];
            currentEnemySpawn++;
            time = 0;
            textWaves.text = "";
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
        int i = 0;
        while(i < enemies.Length){
            if (enemies[i] == null) {
                Enemy2D[] tmp = new Enemy2D[enemies.Length - 1];
                for (int j = 0; j < i; j++)
                    tmp[j] = enemies[j];
                for (int j = i; j < enemies.Length - 1; j++)
                    tmp[j] = enemies[j + 1];
                enemies = new Enemy2D[tmp.Length];
                for (int j = 0; j < enemies.Length; j++)
                    enemies[j] = tmp[j];
                i--;
            }
            i++;
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
