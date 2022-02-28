using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public string[] enemyNames;
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    public List<GameObject> enemies;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            KillAllEnemies();

        if (Input.GetKeyDown(KeyCode.B))
            KillSpecificEnemy("_B");
    }

    /// <summary>
    /// Spawns enemies at the spawn point locations
    /// </summary>
    void SpawnEnemy()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int rnd = Random.Range(0, enemyTypes.Length);
            GameObject go = Instantiate(enemyTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(go);
        }
    }

    /// <summary>
    /// Kills all enemies that meet the specified condition
    /// </summary>
    /// <param name="_condition">The string condition to chack</param>
    void KillSpecificEnemy(string _condition)
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[0].name.Contains(_condition))
                KillEnemy(enemies[0]);
        }
    }

    /// <summary>
    /// Kills all enemies in the scene
    /// </summary>
    void KillAllEnemies()
    {
        int eCount = enemies.Count;
        for(int i = 0; i < eCount; i++)
        {
            KillEnemy(enemies[0]);
        }
    }

    /// <summary>
    /// Kills an enemy based off the GameObject passed in
    /// </summary>
    /// <param name="_enemy">The GameObject of the Enemy</param>
    void KillEnemy(GameObject _enemy)
    {
        if (enemies.Count == 0)
            return;

        Destroy(_enemy);
        enemies.Remove(_enemy);
    }
}
