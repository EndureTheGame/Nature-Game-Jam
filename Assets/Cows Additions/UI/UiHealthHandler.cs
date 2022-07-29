using System.Collections;
using UnityEngine;

public class UiHealthHandler : MonoBehaviour
{
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;

    public int hp = 3;

    public void RemoveHeart()
    {
        hp--;
        
        switch (hp)
        {
            case 2:
                heart3.SetActive(false);
                break;
            case 1:
                heart2.SetActive(false);
                break;
            case 0:
                heart1.SetActive(false);
                break;
        }
    }

    public void AddHeart()
    {
        hp++;
        
        switch (hp)
        {
            case 1:
                heart1.SetActive(true);
                break;
            case 2:
                heart2.SetActive(true);
                break;
            case 3:
                heart3.SetActive(true);
                break;
        }
    }
}