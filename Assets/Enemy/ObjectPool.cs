using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(1,50)] int poolSize = 5;
    [SerializeField] [Range(0.1f,30f)] float spawnTimer = 0.5f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize;i++)
        {
            pool[i] = Instantiate(enemy,transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        foreach(var o in pool)
        {
            if(!o.activeInHierarchy)
            {
                o.SetActive(true);
                return;
            }
        }
    }
}
