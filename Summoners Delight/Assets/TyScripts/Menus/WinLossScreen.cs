using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossScreen : MonoBehaviour
{
    public TMP_Text playerStatsText;
    // Start is called before the first frame update
    void Start()
    {
        playerStatsText.text = "CapturedTowns: " + ResourceScript.instance.capturedTowns + " / " + ResourceScript.instance.TotalTowns + "\n" +
            "Bodies: " + ResourceScript.instance.bodies + "\n" +
            "Gold: " + ResourceScript.instance.gold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
