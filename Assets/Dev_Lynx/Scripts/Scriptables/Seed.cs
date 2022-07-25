using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "Seeds")]
public class Seed : ScriptableObject
{
    public string seedType;
    public GameObject seedPrefab;
    public int ammo;        //How much reserve ammo it starts with? (default to 0)
    
    int stash;

    public void Initialize() {
        stash = ammo;
    }

    public bool canFireSeed() {
        if(stash > 0) {
            stash -= 1;
            return true;
        } else {
            return false;
        }
    }


    public int GetStash() {
        return stash;
    }

    public void AddToStash(int amount) {
        stash += amount;
    }
}
