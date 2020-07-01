using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverlayUI : MonoBehaviour
{
    public GameObject finishPopup;
    public int finishScore;
    public Text finishScoreText;

    public GameObject pausePopup;

    public void Init() {
        finishPopup.SetActive(false);
        pausePopup.SetActive(false);
    }

    public void Finish() {
        finishPopup.SetActive(true);
        finishScore = GameMainUI.I.GetScore();
        finishScoreText.text = finishScore.ToString();
    }

    public void Pause() {
        pausePopup.SetActive(true);
        GameTimer.I.StopGame();
    }

    public void Continue() {
        pausePopup.SetActive(false);
        GameTimer.I.PlayGame();
    }
}
