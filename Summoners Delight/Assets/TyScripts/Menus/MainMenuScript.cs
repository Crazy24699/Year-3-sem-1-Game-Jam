using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject MenuPanel;
    public void StartButton()
    {
        SceneManager.LoadScene("MapScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
