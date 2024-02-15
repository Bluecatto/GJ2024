using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private DayNightCycle cycleHandler;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private Transform[] enemySpawnpoint;
    private bool spawned;

    private float interval;
    private float difficultyScaling;
    // Start is called before the first frame update
    void Start()
    {
        
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
        else if (cycleHandler.isDay)
        {
            spawned = false;
        }
    }

    private void SpawnEnemy(int enemyType)
    {
        Instantiate(enemy[enemyType], enemySpawnpoint[Random.Range(0, enemySpawnpoint.Length)]);
    }
}
