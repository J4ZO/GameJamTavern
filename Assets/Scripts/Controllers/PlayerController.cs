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
    [SerializeField] private float speedBulletX = 30f;

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
            Vector2 speedFinal = new Vector2(speedBulletX,0f);
            ShootingSystem.Instance.CreateBullet(bulletSpawn,speedFinal,"Enemy");
        }
    }


    private void FixedUpdate()
    {
        Vector2 direction = moveAction.action.ReadValue<Vector2>();
        _player.Move(direction, moveSpeed );    
    }
}
