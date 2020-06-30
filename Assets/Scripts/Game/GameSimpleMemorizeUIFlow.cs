using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSimpleMemorizeUIFlow : MonoBehaviour
{
    public GameObject puasePopup;
    public GameObject finishPopup;

    void Start() {
        DisableOverlayUIPause();
    }

    void EnableOverlayUIPause() {
        puasePopup.SetActive(true);

        Time.timeScale = 0f;
    }

    void DisableOverlayUIPause() {
        puasePopup.SetActive(false);

        Time.timeScale = 1f;
    }

    public void EnableOverlayUIFinish() {
        finishPopup.SetActive(true);

        Time.timeScale = 0f;
    } 

    public void ClickPause() {
        EnableOverlayUIPause();
    }

    public void ClickMenu() {
        DisableOverlayUIPause();

        SceneManager.LoadScene("Menu");
    }

    public void ClickRe() {
        DisableOverlayUIPause();
    }
}
