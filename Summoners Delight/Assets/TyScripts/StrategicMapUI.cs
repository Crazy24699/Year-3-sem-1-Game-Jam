using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StrategicMapUI : MonoBehaviour
{
    public TMP_Text bodiesText;
    public TMP_Text bodiesIncrease;

    public TMP_Text goldText;
    public TMP_Text goldIncrease;

    public TMP_Text capturedTowns;
    public TMP_Text maxTowns;

    public GameObject researchPanel;
    public ResearchManager researchManager;

    void Update()
    {
        bodiesText.text = Mathf.Round(ResourceScript.instance.bodies).ToString();
        bodiesIncrease.text = " + " + ResourceScript.instance.bodiesPerSec.ToString();

        goldText.text = Mathf.Round(ResourceScript.instance.gold).ToString();
        goldIncrease.text =" + " + ResourceScript.instance.goldPerSec.ToString();

        capturedTowns.text = ResourceScript.instance.capturedTowns.ToString();
        maxTowns.text = " / " + ResourceScript.instance.TotalTowns.ToString();
    }
    public void ResearchButtonPress()
    {
        if(researchPanel.activeSelf == false)
        {
            researchPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if(researchPanel.activeSelf == true)
        {
            researchPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
