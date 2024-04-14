using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManagerScript : MonoBehaviour
{
    public TownScript[] towns;
    public bool[] conqueredTowns;
    // Start is called before the first frame update
    void Start()
    {
        towns = GetComponentsInChildren<TownScript>();
        SetTownStates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetTownStates()
    {
        if(ResourceScript.instance.townStates.Length == 0)
        {
            conqueredTowns = new bool[towns.Length];
            for(int i = 0; i < towns.Length; i++)
            {
                conqueredTowns[i] = towns[i].conquered;
            }
        }else
        {
            conqueredTowns = ResourceScript.instance.townStates;
            for(int i = 0 ;i < towns.Length ;i++)
            {
                towns[i].conquered = conqueredTowns[i];
                if (conqueredTowns[i])
                {
                    ResourceScript.instance.capturedTowns++;
                }
            }
        }
        ResourceScript.instance.TotalTowns = towns.Length;
    }
}
