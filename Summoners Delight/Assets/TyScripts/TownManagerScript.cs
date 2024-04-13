using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManagerScript : MonoBehaviour
{
    public TownScript[] towns;
    // Start is called before the first frame update
    void Start()
    {
        towns = GetComponentsInChildren<TownScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void setTownStates()
    {
        foreach (var town in towns)
        {
        }
    }
}
