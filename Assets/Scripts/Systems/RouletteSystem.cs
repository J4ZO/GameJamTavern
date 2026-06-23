using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class RouletteSystem : MonoBehaviour
{

    [Serializable]
    private struct Case
    {
        public string name;
        public string description;
        public RouletteSO script;
        [Range(0f, 100f)] public float value;
    }

    [Header("Variables")] [SerializeField] private float delayCase;
    private RouletteSO _currentEffect;

    [Header("References")] [SerializeField]
    private TextMeshProUGUI textCase;


    [Header("Options Weight")] [SerializeField]
    private List<Case> cases;


    void Start()
    {
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
        int value;
        _currentEffect?.Remove();
        var ca = SelectRoulette(cases);
        _currentEffect = ca.script;
        
        
        if (ca.name != "deadEnemy" && ca.name != "cantShoot" && ca.name != "deadPlayer")
        {
            value = Random.Range(0, 3);
        }
        else
        {
            value = 3;
        }
        

        Debug.Log(_currentEffect.name + " : entidad" + value);
        
        UpdateTextCase(ca, value);
        
        _currentEffect.Apply(value);

        AudioManager.Instance.PlayClip(2);
        
        StartCoroutine(RemoveEffect(_currentEffect));
    }

    private IEnumerator RemoveEffect(RouletteSO rouletteEffect)
    {
        yield return new WaitForSeconds(10f);
        if (_currentEffect == rouletteEffect)
        {
            rouletteEffect.Remove();
            _currentEffect = null;
        }
    }

    private void UpdateTextCase(Case c, int unit)
    {
        string value;
    
        if (unit == 0)
        {
            value = "- Player";
        }else if (unit == 1)
        {
            value = "- Enemy";
        }
        else if(unit == 2)
        {
            value = "- everyone";
        }
        else
        {
            value = "";
        }
        
        textCase.text = c.description + " " + value;
    
    }

}

