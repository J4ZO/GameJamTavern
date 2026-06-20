using System;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Boss _boss;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boss = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        _boss.SetSpeedDirection();
    }

    private void FixedUpdate()
    {
        _boss.MoveBoss();
    }
}
