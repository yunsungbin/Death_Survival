using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnerPoint;
    public SpawnData[] spawnData;

    int Level;
    float timer;

    void Awake()
    {
        spawnerPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        Level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);

        if(timer > spawnData[Level].spawnTime)
        {
            timer = 0;
            Spawn();    
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnerPoint[Random.Range(1, spawnerPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[Level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}
