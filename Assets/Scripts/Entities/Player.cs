using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Move(Vector2 dir, float speed)
    {
        rb.MovePosition(rb.position + dir * (speed * Time.fixedDeltaTime));
    }
}
