using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongHold : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0)
        {
            //End the game

            //Destroy(gameObject);
        }
    }

    public int TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;

        return CurrentHealth;
    }

}
