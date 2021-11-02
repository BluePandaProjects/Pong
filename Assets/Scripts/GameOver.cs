using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Replay()
    {
        Debug.Log("Replay Pressed");

        SceneManager.LoadScene("PlayField");
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu Pressed");

        SceneManager.LoadScene("MainMenu");
    }
}
