using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Game()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
