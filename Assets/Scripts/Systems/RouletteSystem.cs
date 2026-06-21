using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RouletteSystem : MonoBehaviour
{
    
    [Serializable] private struct Case
    {
        public string name;
        public RouletteSO script;
        [Range(0f, 100f)] public float value;
    }

    [Header("Variables")] 
    [SerializeField] private float delayCase;
    private RouletteSO _currentEffect;
    
    [Header("References")]
    private SpawnSystem _spawnSystem;
    
    
    [Header("Options Weight")] 
    [SerializeField] private List<Case> cases;
    
    
    void Start()
    {
        _spawnSystem = GetComponent<SpawnSystem>();
        EnableRoulette();
    }
    

    public void EnableRoulette()
    {
        StartCoroutine(StartRoulette());
    }

    public void StopRoulette()
    {
        StopCoroutine(StartRoulette());
    }


    private IEnumerator StartRoulette()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayCase);
            ApplyEffect();
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
    
    
    private void ApplyEffect()
    {
        _currentEffect?.Remove();
        var ca = SelectRoulette(cases);
        
        _currentEffect = ca.script;
        
        int value = Random.Range(0, 3);
        
        Debug.Log(_currentEffect.name + " : entidad" + value);
        _currentEffect.Apply(value);
        
        
        StartCoroutine(RemoveEffect(_currentEffect));
    }

    private IEnumerator RemoveEffect(RouletteSO  rouletteEffect)
    {
        yield return new WaitForSeconds(10f);
        if (_currentEffect == rouletteEffect)
        {
            rouletteEffect.Remove();
            _currentEffect = null;
        }
    }
    
}

