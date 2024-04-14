using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownScript : MonoBehaviour
{
    public bool conquered;
    public int availableGold;       //
    public float bodiesMult;        //the amount of bodies added to the per second tick after this town is sieged
    public GameObject levelButton;  //the button for loading the siege scene
    public string townID;           //the unique ID of the town
    public string siegeScene;       //the name of the scene used when the attack button is pressed
    public Sprite city;
    public Sprite conqueredCity;
    public SpriteRenderer renderer;

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
        if(conquered == true)
        {
            renderer.sprite = conqueredCity;
        }
        else
        {
            renderer.sprite = city;
        }
    }
    public void BeginSiege()
    {
        ResourceScript.instance.currentBesiegedTown = this;
        
        //loads the siege scene
        SceneManager.LoadScene(siegeScene);
    }
    private void Start()
    {
        //if the sieged town in the resource singleton is this town then set it to null and change conquered to true
        if(ResourceScript.instance.currentBesiegedTown == null)
        {
            return;
        }
        if(ResourceScript.instance.currentBesiegedTown.townID == townID)
        {
            conquered = true;
            ResourceScript.instance.currentBesiegedTown = null;
        }
    }
}
