using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private SpawnSystem spawnSystem;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnSystem.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
