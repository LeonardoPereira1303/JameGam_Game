using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectableScore;
    public int score;
    [SerializeField] public int maxScore;
    [SerializeField]GameObject scriptObject;
    public Collider2D igluCollider;

    void Start()
    {        
        //collectableScore.text = score + " /6";
        collectableScore.text = score + $" /{maxScore}";
    }

    public void IncreaseScore()
    {
        score++;
        //collectableScore.text = score + " /6";
        collectableScore.text = score + $" /{maxScore}";
    }
}
