using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceScript : MonoBehaviour
{
    public float bodies;        //the total collected bodies used in spawing during attacks/sieges
    public float bodiesPerSec;  //the amount of bodies that increase per second
    public int bodiesMult = 1;  //the multiplier used in the per second calculation

    public float gold;          //currency used for purchasing upgrades
    public float goldPerSec = 0;//the amount of gold that ticks upwards every second
    public int goldMult = 1;    //the multipliers used in the final gold calculation

    public int capturedTowns;   //the number of captured towns
    public int TotalTowns;      //the total number of towns

    public bool[] townStates;   //boolean array storing all the states of towns for loading

    public bool lost = false;   //bool for checking if the game is lost
    public bool won = false;    //bool checking if the game is won

    public TownScript currentBesiegedTown;  //the current besieged town for level reset
    public static ResourceScript instance { get; private set; } //singleton implementation

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
        //checks if game is won or lost
        WinGame();
        GameOver();
    }

    //method for increasing the base number of bodies per second
    public void IncreaseBodiesRate(float increaseAmount)
    {
        bodiesPerSec += increaseAmount;
    }

    //method for increasing the base gold per second
    public void IncreaseGoldRate(float increaseAmount)
    {
        goldPerSec += increaseAmount;
    }

    //calculates the total number of bodies per second and adds to the total
    public void CalcBodies()
    {
        bodies = bodies + (bodiesMult * (bodiesPerSec * Time.deltaTime)); 
    }

    //calculates the total ngold per second and adds to the total
    public void CalcGold()
    {
        gold = gold + (goldMult * (goldPerSec * Time.deltaTime));
    }

    //method to increase the multiplier for bodies used in the final body calculation
    public void IncreaseBodiesMult(int increaseAmount)
    {
        bodiesMult += increaseAmount;
    }
    
    //method to increase the gold multiplier used in final gold calculation
    public void IncreaseGoldMult(int increaseAmount)
    {
        goldMult += increaseAmount;
    }

    //gameover logic check
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

    //win game logic check
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
