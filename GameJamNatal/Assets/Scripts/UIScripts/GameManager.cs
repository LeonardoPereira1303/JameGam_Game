using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AudioManager audioManager;
    public string sceneName;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other.gameObject.name} entrou no trigger!");

        // Verifica se o objeto que entrou no trigger � o Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detectado no colisor.");

            // Verifica se o score atual � igual ao m�ximo
            if (scoreManager != null && scoreManager.score == scoreManager.maxScore)
            {
                Debug.Log("MaxScore alcan�ado. Carregando cena...");
                SceneManager.LoadScene(sceneName);
                audioManager.PlaySFX(audioManager.sfxNetxLevel);
            }
            else
            {
                Debug.Log("Score insuficiente para avan�ar.");
            }
        }
    }

    
}
