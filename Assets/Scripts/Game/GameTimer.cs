using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer I;
    void Awake() {
        I = this;
    }

    public float fullTime;
    public float currentTime;
    public float answerTime;

    bool isPlay;

    public void Init()
    {
        fullTime = 30f;
        currentTime = fullTime;

        isPlay = false;
    }

    public void Stop() {
        answerTime = 0f;

        isPlay = false;
    }

    public void Play() {
        answerTime = 0f;

        isPlay = true;
    }

    public void PlayGame() {
        Time.timeScale = 1f;
    }

    public void StopGame() {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if(!isPlay)
            return;

        currentTime -= Time.deltaTime;
        answerTime += Time.deltaTime;

        if(currentTime <= 0f) {
            StopGame();
            GameMainUI.I.gameOverlayUI.Finish();
        }
    }

    public float GetCurrentTimeValue() {
        return currentTime / fullTime;
    }
}
