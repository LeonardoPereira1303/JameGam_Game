using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameManager triggerHandler;
    [SerializeField] TextMeshProUGUI collectableScore;
    public int score;
    [SerializeField] public int maxScore;
    [SerializeField]GameObject scriptObject;
    public Collider2D igluCollider;
    private bool hasTriggered = false;

    void Start()
    {        
        //collectableScore.text = score + " /6";
        collectableScore.text = score + $" /{maxScore}";
    }

    private void Update()
    {
        if (score == maxScore && triggerHandler != null && !hasTriggered)
        {
            hasTriggered = true; // Garante que o método seja chamado apenas uma vez

            // Encontra o Player dinamicamente
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                Collider2D playerCollider = player.GetComponent<Collider2D>();
                if (playerCollider != null)
                {
                    triggerHandler.HandleTrigger(playerCollider); // Passa o Collider do Player
                }                
            }
            
        }
    }
    public void IncreaseScore()
    {
        score++;
        //collectableScore.text = score + " /6";
        collectableScore.text = score + $" /{maxScore}";
    }
}
