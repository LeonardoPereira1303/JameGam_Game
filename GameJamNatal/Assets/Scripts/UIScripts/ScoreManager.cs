using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectableScore;
    public int score;
    [SerializeField] public int maxScore;

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

    public void VerifyScore()
    {
        if(score == maxScore)
        {
            
        }
    }
}
