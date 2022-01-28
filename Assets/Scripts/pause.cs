using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private int scoreL1 = 0, scoreL2 = 0, bestScore = 0;

    public void BackMenu ()
    {
        SaveScores();
        SceneManager.LoadScene("Menu");
    }

    public void Pausa ()
    {
        Time.timeScale = 0f;
    }

    public void Reanudar ()
    {
        Time.timeScale = 1f;
    }

    public void SaveScores ()
    {
        scoreL1 = PlayerPrefs.GetInt("LocalScoreG1");
        scoreL2 = PlayerPrefs.GetInt("LocalScoreG2");
        bestScore = PlayerPrefs.GetInt("Highscore");
        if(scoreL1 + scoreL2 > bestScore)
        {
            PlayerPrefs.SetInt("Highscore", scoreL1 + scoreL2);
        }
    }
}
