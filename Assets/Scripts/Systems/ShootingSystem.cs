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
        }
    }

    


    public void CreateBullet(Transform bulletPosition,  Vector2 speed, String tagTarget)
    {
        if (_bullets.TrueForAll(bullet => bullet.gameObject.activeSelf) || _bullets.Count == 0)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
            Bullet bullet = newBullet.GetComponent<Bullet>();
            bullet.SetTarget(tagTarget);
            bullet.SetSpeedDirection(speed);
        }
        else
        {
            foreach (var bullet in _bullets)
            {
                if(!bullet.gameObject.activeSelf)
                {
                    bullet.transform.position = bulletPosition.position;
                    bullet.SetTarget(tagTarget);
                    bullet.SetSpeedDirection(speed);
                    bullet.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}
