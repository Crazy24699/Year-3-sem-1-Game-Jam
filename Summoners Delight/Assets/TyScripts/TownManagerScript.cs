using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManagerScript : MonoBehaviour
{
    public TownScript[] towns;
    public bool[] conqueredTowns;
    // Start is called before the first frame update
    private void Awake()
    {
        towns = GetComponentsInChildren<TownScript>();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
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
            ResourceScript.instance.townStates = conqueredTowns;
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
    public int GetTownIndex(TownScript town)
    {
        int index = 0;
        for(int i = 0; i < towns.Length; i++)
        {
            if(town == towns[i])
            {
                index = i; break;
            }
        }
        return index;
    }
}
