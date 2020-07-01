using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainUI : MonoBehaviour
{
    public static GameMainUI I;
    public GameOverlayUI gameOverlayUI;
    void Awake() {
        I = this;
    }

    public int currentScore;
    public Text currentScoreText;

    public Slider timeSlider;
    public Text stateText;

    public void Init() {
        SetScore(0);

        timeSlider.value = 1;
        stateText.text = "Question";
    }

    public void Update() {
        timeSlider.value = GameTimer.I.GetCurrentTimeValue();
    }

    public void Play() {
        stateText.text = "Answer";

        GameTimer.I.Play();
    }

    public void Stop() {
        stateText.text = "Questions";

        GameTimer.I.Stop();
    }
    
    public void SetScore(int score) {
        currentScore = score;

        Commit();
    }

    public void AddScore(int score) {
        currentScore += score;

        Commit();
    }

    public void Commit() {
        currentScoreText.text = currentScore.ToString();
    }

    public int GetScore() {
        return currentScore;
    }
}
