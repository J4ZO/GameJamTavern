using System;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    private Boss _boss;
    [SerializeField] private Image bossHealthBar;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boss = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        _boss.SetSpeedDirection();

        bossHealthBar.fillAmount = _boss.GetHealth() / _boss.GetMaxHealth();
    }

    private void FixedUpdate()
    {
        _boss.MoveBoss();
    }
}
