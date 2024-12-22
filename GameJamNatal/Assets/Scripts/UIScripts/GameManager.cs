using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;

    public void HandleTrigger(Collider2D other)
    {
        Debug.Log($"Trigger manual chamado por {other.gameObject.name}");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Fase2");
            AudioManager.instance.PlaySFX("nextlevel");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other.gameObject.name} entrou no trigger!");
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {            
    //        SceneManager.LoadScene("Fase2");
    //        AudioManager.instance.PlaySFX("nextlevel");
    //    }


    //}
}
