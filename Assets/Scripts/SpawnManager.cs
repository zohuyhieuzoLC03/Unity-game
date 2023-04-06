using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    public GameObject powerupPrefab;
    
    private float spawnRange = 9;

    public int enemyCount;

    public int waveNumber = 1;
    
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, RandomGenerationPos(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private Vector3 RandomGenerationPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomEnemy], RandomGenerationPos(), enemyPrefab[randomEnemy].transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        while (!gameManager.isOver)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                gameManager.updateLevel(waveNumber);
                Instantiate(powerupPrefab, RandomGenerationPos(), powerupPrefab.transform.rotation);
            }
        }
    }
}
