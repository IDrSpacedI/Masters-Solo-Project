using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreAmountOnKill;
    public int currentScore;

    [SerializeField] private TMP_Text score;

    private void Start()
    {
        InitVariable();
    }

    private void InitVariable()
    {
        currentScore = 0;
    }

    public void AddToScore()
    {
        currentScore += scoreAmountOnKill;
        score.text = currentScore.ToString();
    }

}
