using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownScript : MonoBehaviour
{
    public bool conquered;
    public int availableGold;
    public float bodiesMult;
    public GameObject levelButton;
    public string townID;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (conquered == false)
            {
                levelButton.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            levelButton.SetActive(false);
        }
    }
    public void beginLevel()
    {

    }
}
