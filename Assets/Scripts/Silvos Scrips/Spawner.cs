using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int waveNumber = 0;
    public int spawnAmount = 0;
    public int enemiesKilled = 0;
    
    public GameObject[] spawners;
    public GameObject enemy;

    private void Start()
    {
        spawners = new GameObject[4];

        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        StartWave();
    }

    private void Update()
    {
        if(enemiesKilled >= spawnAmount)
        {
            NextWave();
        }
    }
    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy,spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation) ;
    }
    private void StartWave()
    {
        waveNumber = 1;
        spawnAmount = 6;
        enemiesKilled = 0;

        for(int i = 0; i < spawnAmount; i++)
        {
            SpawnEnemy();
        }
        
        if(enemiesKilled >= spawnAmount)
        {
            NextWave();
        }
    }
    public void NextWave()
    {
        waveNumber++;
        spawnAmount += 4;
        enemiesKilled = 0;

        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
}