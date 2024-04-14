using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceScript : MonoBehaviour
{
    public float bodies;
    public float bodiesPerSec;
    public int bodiesMult = 1;

    public float gold;
    public float goldPerSec = 0;
    public int goldMult = 1;

    public int capturedTowns;
    public int TotalTowns;

    public int minionSpeedMult;

    public bool[] townStates;
    public string[] townIDs;

    public bool lost = false;
    public bool won = false;

    public TownScript currentBesiegedTown;
    public static ResourceScript instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Update()
    {
        GameOver();
    }

    public void IncreaseBodiesRate(float increaseAmount)
    {
        bodiesPerSec += increaseAmount;
    }
    public void IncreaseGoldRate(float increaseAmount)
    {
        goldPerSec += increaseAmount;
    }
    public void CalcBodies()
    {
        bodies = bodies + (bodiesMult * (bodiesPerSec * Time.deltaTime)); 
    }
    public void CalcGold()
    {
        gold = gold + (goldMult * (goldPerSec * Time.deltaTime));
    }
    public void IncreaseBodiesMult(int increaseAmount)
    {
        bodiesMult += increaseAmount;
    }
    public void IncreaseGoldMult(int increaseAmount)
    {
        goldMult += increaseAmount;
    }
    public void GameOver()
    {
        if(bodies == 0)
        {
            if(lost == false)
            {
                lost = true;
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
    public void WinGame()
    {
        if(capturedTowns == TotalTowns)
        {
            if(won == false)
            {
                won = true;
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
