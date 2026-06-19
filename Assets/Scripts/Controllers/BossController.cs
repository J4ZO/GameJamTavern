using System;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Boss _boss;
    [SerializeField] private float speedBoss;
    private Vector2 _speedDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boss = GetComponent<Boss>();
        _speedDirection = new Vector2(-speedBoss, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _boss.MoveBoss(_speedDirection);
    }
}
