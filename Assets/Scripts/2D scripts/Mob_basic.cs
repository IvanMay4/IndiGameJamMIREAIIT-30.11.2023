using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Mob_basic
{
    public int spawnTime;
    public MobType mobType;
    public int spawner;
    public bool randomSpawner;
    public bool isSpawned;
}

public enum MobType
{
    Mob_Basic
}
