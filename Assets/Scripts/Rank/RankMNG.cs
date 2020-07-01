using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankMNG : MonoBehaviour
{
    public int[] scoreList = new int[6];
    public Text[] scoreTextList = new Text[6];


    void Start()
    {
        for(int i=0; i<6; i++) {
            scoreList[i] = PlayerPrefs.GetInt("Rank_" + i.ToString(), 0);
        }

        int newScore = PlayerPrefs.GetInt("NewScore", 0);

        if(newScore > scoreList[5]) {
            scoreList[5] = newScore;
        }

        Array.Sort(scoreList);
        Array.Reverse(scoreList);

        PlayerPrefs.SetInt("NewScore", 0);

        for(int i=0; i<6; i++) {
            scoreTextList[i].text = scoreList[i].ToString();
        }

        for(int i=0; i<6; i++) {
            PlayerPrefs.SetInt("Rank_" + i.ToString(), scoreList[i]);
        }
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
}
