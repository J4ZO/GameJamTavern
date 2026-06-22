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
    [SerializeField] private List<GameObject> prefabsEnemies;
    [SerializeField] private List<GameObject> prefabsPlanets;
    
    
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
            Instantiate(SpawnPrefab(prefabsEnemies), spawnPoints[SpawnRandom()].position,SpawnPrefab(prefabsEnemies).transform.rotation);
        }
        else
        {
            Instantiate(SpawnPrefab(prefabsPlanets), spawnPoints[SpawnRandom()].position, SpawnPrefab(prefabsPlanets).transform.rotation);
        }
    }
    
    private int SpawnRandom()
    {
        return Random.Range(0, spawnPoints.Count);
    }

    private GameObject SpawnPrefab(List<GameObject> prefabs)
    {
        int random = Random.Range(0, prefabs.Count);
        
        return prefabs[random];
    }
}
