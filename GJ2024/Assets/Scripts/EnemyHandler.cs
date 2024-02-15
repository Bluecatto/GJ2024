using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private DayNightCycle cycleHandler;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private Transform[] enemySpawnpoint;
    private bool spawned;

    [SerializeField] private float spawnInterval;
    private float intervalTimer;
    private float difficultyScaling;
    // Start is called before the first frame update
    void Start()
    {
        intervalTimer = spawnInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        difficultyScaling = Time.time / 60f;

        if (!cycleHandler.isDay && !spawned)
        {
            for (int i = 0; i < difficultyScaling; i++)
            {
                SpawnEnemy(Random.Range(0,enemy.Length));
            }
            spawned = true;
        }
        else if (intervalTimer < 0f)
        {
            spawned = false;
            intervalTimer = spawnInterval;
        }
        else
        {
            intervalTimer -= Time.deltaTime;
        }
    }

    private void SpawnEnemy(int enemyType)
    {
        Instantiate(enemy[enemyType], enemySpawnpoint[Random.Range(0, enemySpawnpoint.Length)]);
    }
}
