using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSimpleMemorizeScore : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public void SetScore(int score) {
        this.score = score;

        Commit();
    }

    public void AddScore(int score) {
        this.score += score;

        Commit();
    }

    public void Commit() {
        scoreText.text = score.ToString();
    }

    public int GetScore() {
        return score;
    }
}
