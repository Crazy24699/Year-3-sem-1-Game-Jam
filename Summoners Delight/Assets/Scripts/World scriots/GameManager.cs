using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool OnUI = false;
    public bool OnInvalidSpot = false;
    public static GameManager ManagerInstance;

    //happens when an obstacle goes down and the AI needs to change its behaviour 
    public UnityEvent WorldUpdate = new UnityEvent();
    public UnityEvent StopAttacks = new UnityEvent();
    public UnityEvent PlayerLoss = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        if(ManagerInstance != null)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
        ManagerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
