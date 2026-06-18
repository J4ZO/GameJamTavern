using UnityEngine;

public class BossController : MonoBehaviour, IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        Debug.Log("Life boss reduced");
    }
    

    public bool IsDead { get; set; }
}
