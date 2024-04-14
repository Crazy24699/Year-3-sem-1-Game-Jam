using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResource : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        ResourceScript.instance.CalcBodies();
        ResourceScript.instance.CalcGold();
    }
}
