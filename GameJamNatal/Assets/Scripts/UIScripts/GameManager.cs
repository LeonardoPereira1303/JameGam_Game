using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other.gameObject.name} entrou no trigger!");

        // Verifica se o objeto que entrou no trigger é o Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detectado no colisor.");

            // Verifica se o score atual é igual ao máximo
            if (scoreManager != null && scoreManager.score == scoreManager.maxScore)
            {
                Debug.Log("MaxScore alcançado. Carregando cena...");
                SceneManager.LoadScene("Fase2");
                AudioManager.instance.PlaySFX("nextlevel");
            }
            else
            {
                Debug.Log("Score insuficiente para avançar.");
            }
        }
    }

    
}
