using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        PlayerPrefs.SetInt("NewScore", finishScore);
    }

    public void Pause() {
        pausePopup.SetActive(true);
        GameTimer.I.StopGame();
    }

    public void Continue() {
        pausePopup.SetActive(false);
        GameTimer.I.PlayGame();
    }

    public void Menu() {
        GameTimer.I.PlayGame();
        SceneManager.LoadScene("Menu");
    }

    public void Rank() {
        GameTimer.I.PlayGame();
        SceneManager.LoadScene("Rank");
    }
}
