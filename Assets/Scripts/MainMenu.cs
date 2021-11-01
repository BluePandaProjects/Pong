using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadPlayField()
    {
        SceneManager.LoadScene("PlayField");
    }

    public void LoadSettings()
    {
        Debug.Log("Settings Scene will load here");
    }

    public void LoadCredits()
    {
        Debug.Log("Credits Scene will load here");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
