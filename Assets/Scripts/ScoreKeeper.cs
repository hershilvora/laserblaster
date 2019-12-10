using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    private Text scoreText;
    public int score = 0;

    public void Start()
    {
        scoreText = GetComponent<Text>();
    }
    public void Score(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
    }
}
