using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private DayNightCycle cycleHandler;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private Transform[] enemySpawnpoint;
    private bool spawned;

    [SerializeField] private float spawnIntervalMin;
    [SerializeField] private float spawnIntervalMax;
    private float intervalTimer;
    private float difficultyScaling;

    // Start is called before the first frame update
    void Start()
    {
        intervalTimer = Random.Range(spawnIntervalMin,spawnIntervalMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        difficultyScaling = Time.time / 360f;

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
            intervalTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);
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
