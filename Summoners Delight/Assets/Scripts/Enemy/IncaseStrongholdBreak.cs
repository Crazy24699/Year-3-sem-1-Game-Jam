using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IncaseStrongholdBreak : MonoBehaviour
{
    public GameObject castleBase;
    [SerializeField]WallHealth[] walls;
    public void CheckWalls()
    {
        walls = castleBase.GetComponentsInChildren<WallHealth>();
        if(walls.Length == 0)
        {
            WinSiege();
        }
    }
    public void Retreat()
    {
        SceneManager.LoadScene("MapScene");
    }
    private void WinSiege()
    {
        ResourceScript.instance.currentBesiegedTown.ConqueredEffect();
        ResourceScript.instance.currentBesiegedTown.conquered = true;
        SceneManager.LoadScene("MapScene");
    }
}
