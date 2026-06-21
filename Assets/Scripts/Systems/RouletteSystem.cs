using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RouletteSystem : MonoBehaviour
{
    
    public static event Action OnRouletteEvent;
    
    [Serializable] private struct Case
    {
        public string name;
        [Range(0f, 100f)] public float value;
        public bool isUnique;
    }

    [Header("Variables")] [SerializeField] private float delayCase;
    
    [Header("Options Weight")] 
    [SerializeField] private List<Case> cases;
    
    
    void Start()
    {
        EnableRoulette();
    }

    
    void Update()
    {
        
    }

    public void EnableRoulette()
    {
        StartCoroutine(StartRoulette());
    }

    public void StopRoulette()
    {
        StopCoroutine(StartRoulette());
    }


    IEnumerator StartRoulette()
    {
        while (true)
        {
            var ca = SelectRoulette(cases);
            Debug.Log("Case choose: " + ca.name);
            yield return new WaitForSeconds(delayCase);
        }
    }

    private Case SelectRoulette(List<Case> casesRoulette)
    {
        var value = Random.Range(0f, 100f);

        foreach (var c in casesRoulette)
        {
            value -= c.value;

            if (value <= 0f)
            {
                return c;
            }
        }

        return casesRoulette[-1];

    }

    private void SelectPlayerEnemy()
    {
        
        
    }
    
}

