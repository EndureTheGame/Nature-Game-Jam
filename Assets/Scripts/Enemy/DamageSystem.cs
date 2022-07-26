using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public float health;

    public void Start()
    {
        health = 200.0f;  
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        { 
            FindObjectOfType<GameManager>().GameOver();    
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
