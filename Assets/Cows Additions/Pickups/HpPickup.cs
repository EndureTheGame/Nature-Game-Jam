using UnityEngine;

public class HpPickup : MonoBehaviour
{
    private UiHealthHandler hpUi;
    [SerializeField] private GameObject parentObject;

    private void Awake()
    {
        hpUi = FindObjectOfType<UiHealthHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!(other.GetComponent<DamageSystem>().health < 3)) return;
            
            hpUi.AddHeart();
            other.gameObject.GetComponent<DamageSystem>().AddHealth();
            Destroy(parentObject);
        }
    }
}