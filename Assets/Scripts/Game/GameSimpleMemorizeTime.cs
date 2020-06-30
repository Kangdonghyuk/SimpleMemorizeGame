using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSimpleMemorizeTime : MonoBehaviour
{
    public Text stateText;
    public Slider timeSlider;
    public float fullTime;
    public float currentTime;
    public float answerTime;
    
    bool isPlay;

    public void Init() {
        fullTime = 30f;
        currentTime = fullTime;

        timeSlider.value = 1f;

        isPlay = false;

        stateText.text = "Questions";
    }

    public void Stop() {
        isPlay = false;
        answerTime = 0f;

        stateText.text = "Questions";
    }

    public void Play() {
        isPlay = true;
        answerTime = 0f;

        stateText.text = "Answer";
    }

    void Update() {
        if(!isPlay)
            return;

        currentTime -= Time.deltaTime;
        answerTime += Time.deltaTime;

        if(currentTime <= 0f) {
            GameSimpleMemorize.I.gameSimpleMemorizeUIFlow.EnableOverlayUIFinish();
        }

        timeSlider.value = (currentTime / fullTime);    
    }
}
