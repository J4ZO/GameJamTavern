using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> prefabs;
    
    
    [Header("Variables")]
    public float spawnRate;
    [SerializeField] private float timeDelay;

    private void Update()
    {
        if(spawnRate > 0.5f) spawnRate -= timeDelay * Time.deltaTime;
    }


    public void Spawn()
    {
        StartCoroutine(SpawnRoutine());
    }

    public void StopSpawn()
    {
        StopCoroutine(SpawnRoutine());
    }
    
    
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            InstanceRandom();
        }
    }


    private void InstanceRandom()
    {
        var value = Random.Range(0f, 1f);

        if (value < 0.6f)
        {
            Instantiate(prefabs[0], spawnPoints[SpawnRandom()].position,prefabs[0].transform.rotation);
        }
        else
        {
            Instantiate(prefabs[1], spawnPoints[SpawnRandom()].position, prefabs[1].transform.rotation);
        }
    }
    
    private int SpawnRandom()
    {
        return Random.Range(0, spawnPoints.Count);
    }
}
