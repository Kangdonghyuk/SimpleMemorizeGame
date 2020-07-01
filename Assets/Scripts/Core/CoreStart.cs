using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreStart : MonoBehaviour
{
    void Awake() {
        Screen.SetResolution(1080, 1920, true);
    }

    void Start() {
        SceneManager.LoadScene("Menu");
    }
}
