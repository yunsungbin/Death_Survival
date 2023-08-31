using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnerPoint;

    float timer;

    void Awake()
    {
        spawnerPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.5f)
        {
            timer = 0;
            Spawn();    
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
        enemy.transform.position = spawnerPoint[Random.Range(1, spawnerPoint.Length)].position;
    }
}
