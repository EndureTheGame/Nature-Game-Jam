using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public float health;

    public void Awake()
    {
        health = 3f;  
    }

    public void TakeDamage()
    {
        health -= 1;
        
        if (health <= 0)
        { 
            FindObjectOfType<GameManager>().GameOver();    
        }
    }

    public void AddHealth()
    {
        switch (health)
        {
            case >= 3:
                health = 3;
                break;
            case < 3:
                health += 1;
                break;
        }
    }
}
