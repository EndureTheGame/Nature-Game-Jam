using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBall : MonoBehaviour
{
    
    public int damamge = 25;
    private DamageSystem damageSystem;
    public GameObject player;
    public float TimeLeft = 50;
    
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        damageSystem = player.GetComponent<DamageSystem>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<DamageSystem>().TakeDamage(25);
        }
        else 
        { 
            Destroy(gameObject); 
        }
    }
}

