using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player _player;
    
    [Header("References")]
    [SerializeField] private Transform bulletSpawn;
    
    [Header("Variables")]
    [SerializeField] float moveSpeed;

    [Header("Actions")] 
    [SerializeField] private InputActionReference  moveAction;
    [SerializeField] private InputActionReference  shootAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shootAction.action.WasPressedThisFrame())
        {
            ShootingSystem.Instance.CreateBullet(bulletSpawn);
        }
    }


    private void FixedUpdate()
    {
        Vector2 direction = moveAction.action.ReadValue<Vector2>();
        _player.Move(direction, moveSpeed );    
    }
}
