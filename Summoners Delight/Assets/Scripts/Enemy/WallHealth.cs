using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    const int MaxHealth = 100;
    public int CurrentHealth;

    

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public int TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0)
        {
            //reference the script for pathfinding and have it run a updated scan on what is walkable and what isnt
            Destroy(this.gameObject);
            GameManager.ManagerInstance.WorldUpdate.Invoke();
            return CurrentHealth = 0;
        }

        return CurrentHealth;
    }

}
