using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MobSpawner : MonoBehaviour
{
    public List<GameObject> mobsPrefabs;
    public List<Mob_basic> mobs;

    private void Update()
    {
        foreach (Mob_basic mob_basic in mobs )
        {
            if (mob_basic.isSpawned == false && mob_basic.spawnTime <= Time.time)
            {
                if (mob_basic.randomSpawner)
                {
                    mob_basic.spawner = Random.Range(0, transform.childCount);
                }

                GameObject mobInstance = Instantiate(mobsPrefabs[(int)mob_basic.mobType], transform.GetChild(mob_basic.spawner).transform);
                transform.GetChild(mob_basic.spawner).GetComponent<SpawnPoint>().mobs.Add(mobInstance);
                mob_basic.isSpawned = true;
            }
        }
    }
}