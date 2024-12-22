using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    ScoreManager scoreManager;

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
            
        }
    }
}
