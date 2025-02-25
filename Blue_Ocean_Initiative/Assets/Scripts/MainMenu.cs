using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 200, 50), "Start Game"))
        {
            SceneManager.LoadScene("MainGameScene");
        }
        if (GUI.Button(new Rect(100, 175, 200, 50), "Credits"))
        {
            SceneManager.LoadScene("CreditsScene");
        }
        if (GUI.Button(new Rect(100, 250, 200, 50), "End Game"))
        {
            Application.Quit();
            Debug.Log("Game Quit!");
        }
    }
}