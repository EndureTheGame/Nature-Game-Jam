using System;
using UnityEngine;

public class TriggerHeartRemoval : MonoBehaviour
{
    private UiHealthHandler uiHp;

    private void Awake()
    {
        uiHp = FindObjectOfType<UiHealthHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiHp.RemoveHeart();
        }
    }
}