using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public float bodies;
    public float bodyIncrease;
    public int capturedTowns;
    public int TotalTowns;
    public int plunder;
    public int minionSpeed;
    public bool InSiege = false;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(!InSiege)
        {
            bodies += bodyIncrease * Time.deltaTime;
        }
    }
    public void IncreaseBodiesRate(float increaseAmount)
    {
        bodyIncrease += increaseAmount;
    }
}
