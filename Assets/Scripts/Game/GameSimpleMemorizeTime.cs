using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSimpleMemorizeTime : MonoBehaviour
{
    public Slider timeSlider;
    public float fullTime;
    public float currentTime;
    
    bool isPlay;

    public void Init() {
        fullTime = 30f;
        currentTime = fullTime;

        timeSlider.value = 1f;

        isPlay = false;
    }

    public void Stop() {
        isPlay = false;
    }

    public void Play() {
        isPlay = true;
    }

    void Update() {
        if(!isPlay)
            return;

        currentTime -= Time.deltaTime;

        timeSlider.value = (currentTime / fullTime);    
    }
}
