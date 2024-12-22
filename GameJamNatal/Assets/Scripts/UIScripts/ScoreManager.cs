using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectableScore;
    int score;

    void Start()
    {
        collectableScore.text = score + " /3";
    }

    public void IncreaseScore()
    {
        score++;
        collectableScore.text = score + " /3";
    }
}
