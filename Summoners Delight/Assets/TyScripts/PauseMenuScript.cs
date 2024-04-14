using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf == false)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void QuitButtonPress()
    {
        Time.timeScale = 1.0f;
        Application.Quit();
    }

    public void ResumeButtonPress()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
