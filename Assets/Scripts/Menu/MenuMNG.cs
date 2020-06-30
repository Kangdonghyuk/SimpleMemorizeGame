using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMNG : MonoBehaviour
{
    public void ClickSimple() {
        SceneManager.LoadScene("Memorize");
    }
    
    public void ClickRank() {

    }

    public void ClickExit() {
        Application.Quit();
    }
}
