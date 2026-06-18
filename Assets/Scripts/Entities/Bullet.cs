using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable()
    {
        ShootingSystem.Instance.AddBullet(this);
    }
    
    
    public void Move(Vector2 speed)
    {
        _rb.MovePosition(_rb.position + speed * Time.fixedDeltaTime);
    }
    
}
