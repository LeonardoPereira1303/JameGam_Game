using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    AudioManager audioManager;
    ScoreManager scoreManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void Start()
    {
        scoreManager = GameObject.Find("UI").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.IncreaseScore();
            gameObject.SetActive(false);
            audioManager.PlaySFX(audioManager.sfxCollect);          
        }
    }
}
