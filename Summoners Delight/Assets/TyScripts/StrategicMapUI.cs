using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StrategicMapUI : MonoBehaviour
{
    public TMP_Text bodiesText;
    public TMP_Text bodiesIncrease;
    public TMP_Text capturedTowns;
    public TMP_Text maxTowns;
    public GameObject researchPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bodiesText.text = Mathf.Round(ResourceScript.instance.bodies).ToString();
    }
    public void researchButtonPress()
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
