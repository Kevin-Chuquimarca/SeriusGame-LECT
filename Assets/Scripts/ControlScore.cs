using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScore : MonoBehaviour
{
    public int bestScore;
    public Text bestScoreText;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Highscore");
    }

    void Update() {
        bestScoreText.text = bestScore.ToString();
    }

    public void ResetPref ()
    {
        PlayerPrefs.DeleteAll();
        bestScore = 0;
    }
}
