using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        LeanTween.cancelAll();
        SceneManager.LoadScene("Game");
    }
}
