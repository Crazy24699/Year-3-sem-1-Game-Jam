using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunction : MonoBehaviour
{

    public enum MinionList
    {
        Skeleton,
        Zombie
    };

    protected MinionList[] MinionArray;

    public MinionList ChosenMinion;

    public MinionSpawning SpawningScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindScriptDelay());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FindScriptDelay()
    {
        yield return new WaitForSeconds(0.10f);
        SpawningScript = FindObjectOfType<MinionSpawning>();
        SpawningScript.SpawnNum = 1;
    }

    public void SetMinion(int Minion)
    {
        ChosenMinion = (MinionList)Minion;
        if (ChosenMinion.Equals(MinionList.Zombie))
        {
            SpawningScript.SpawnNum = 2;
        }
        else
        {
            SpawningScript.SpawnNum = 1;
        }
    }

    public void SetCursorState(bool State)
    {
        GameManager.ManagerInstance.OnUI = State;
        GameManager.ManagerInstance.OnInvalidSpot = State;
    }

}
