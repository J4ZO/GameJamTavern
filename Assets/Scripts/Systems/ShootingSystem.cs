using System;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private List<Bullet> _bullets;
    
    public static ShootingSystem Instance;

    private void Awake()
    {
        _bullets = new List<Bullet>();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    public void AddBullet(Bullet bullet)
    {
        if(!_bullets.Contains(bullet))
        {
            _bullets.Add(bullet);
            Debug.Log("Bullet Added.  Bullet Count: " + _bullets.Count);
        }
    }

    


    public void CreateBullet(Transform bulletPosition,  Vector2 speed)
    {
        if (_bullets.TrueForAll(bullet => bullet.gameObject.activeSelf) || _bullets.Count == 0)
        {
            Debug.Log("Bullet Full or Created first time");
            GameObject newBullet = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
            Bullet bullet = newBullet.GetComponent<Bullet>();
            
            bullet.SetSpeedDirection(speed);
        }
        else
        {
            Debug.Log("Bullet pool");
            foreach (var bullet in _bullets)
            {
                if(!bullet.gameObject.activeSelf)
                {
                    bullet.transform.position = bulletPosition.position;
                    bullet.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}
