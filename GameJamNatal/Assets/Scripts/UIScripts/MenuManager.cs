using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public void Game()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Defeat()
    {
        SceneManager.LoadScene("Defeat");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
