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
    public string siegeScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (conquered == false)
            {
                Debug.Log("entering");
                levelButton.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("exiting");
            levelButton.SetActive(false);
        }
    }
    public void BeginSiege()
    {
        ResourceScript.instance.currentBesiegedTown = this;
    }
    private void Start()
    {
        if(ResourceScript.instance.currentBesiegedTown == this)
        {
            ResourceScript.instance.currentBesiegedTown = null;
        }
    }
}
