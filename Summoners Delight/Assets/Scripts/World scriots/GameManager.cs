using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager ManagerInstance;


    //happens when an obstacle goes down and the AI needs to change its behaviour 
    public UnityEvent WorldUpdate = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ManagerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
