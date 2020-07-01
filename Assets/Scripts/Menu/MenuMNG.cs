using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMNG : MonoBehaviour
{
    public Text levelString;

    public void ClickSimple() {
        SceneManager.LoadScene("Game");
    }
    
    public void ClickRank() {

    }

    public void ClickExit() {
        Application.Quit();
    }

    public void ClickLevelUp() {
        CoreInfo.LevelUp();
        levelString.text = CoreInfo.LevelString;
    }

    public void ClickLevelDown() {
        CoreInfo.LevelDown();
        levelString.text = CoreInfo.LevelString;
    }
}
