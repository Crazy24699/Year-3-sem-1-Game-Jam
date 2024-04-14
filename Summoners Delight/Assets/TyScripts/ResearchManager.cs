using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchManager : MonoBehaviour
{
    public GameObject[] researchButtons;
    public ResearchObject[] techs;
    public TMP_Text[] names;
    public TMP_Text[] descriptions;
    public TMP_Text[] cost;
    public Image[] artworks;
    public ResearchObject[] buyableTech;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        buyableTech = new ResearchObject[3];
        RefreshList();
        DisableExpensiveOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonOptions(int index)
    {
        buyableTech[index].UniqueEffect();
        RefreshList();
        DisableExpensiveOptions();
    }
    public void RefreshList()
    {
        RandomResearchObjects();
        for (int i = 0; i < researchButtons.Length; i++)
        {
            names[i].text = buyableTech[i].name;
            descriptions[i].text = buyableTech[i].description;
            cost[i].text = buyableTech[i].goldCost.ToString();
            artworks[i].sprite = buyableTech[i].artwork;
        }
    }
    public void RandomResearchObjects()
    {
        int randomIndex;
        for(int i = 0; i < researchButtons.Length; i++)
        {
            randomIndex = Random.Range(0, techs.Length);
            buyableTech[i] = techs[randomIndex];
        }
    }
    public void DisableExpensiveOptions()
    {
        for(int i = 0; i < researchButtons.Length; i++)
        {
            //Debug.Log(i);
            if(ResourceScript.instance.gold < buyableTech[i].goldCost)
            {
                researchButtons[i].SetActive(false);
            }
            else
            {
                researchButtons[i].SetActive(true);
            }
        }
    }
}
