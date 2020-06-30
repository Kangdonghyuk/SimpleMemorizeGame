using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSimpleMemorizeUIFlow : MonoBehaviour
{
    public GameObject overlayUI;

    void Start() {
        DisableOverlayUI();
    }

    void EnableOverlayUI() {
        overlayUI.SetActive(true);

        Time.timeScale = 0f;
    }

    void DisableOverlayUI() {
        overlayUI.SetActive(false);

        Time.timeScale = 1f;
    }

    public void ClickPause() {
        EnableOverlayUI();
    }

    public void ClickMenu() {
        DisableOverlayUI();

        SceneManager.LoadScene("Menu");
    }

    public void ClickRe() {
        DisableOverlayUI();
    }
}
