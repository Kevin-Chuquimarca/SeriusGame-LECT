using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class User
{
    public string nameUser;
    public int score1;
    public int score2;
    public int countLaunchGame1;
    public int incorrectLaunchGame1;
    public int correctLaunchGame1;
    public int countLaunchGame2;
    public int incorrectLaunchGame2;
    public int correctLaunchGame2;
    public User(){
        nameUser = DBManager.namePlayer;
        score1 = DBManager.score1Player;
        countLaunchGame1 = DBManager.countLaunchPlay1;
        correctLaunchGame1 = DBManager.score1Player;
        incorrectLaunchGame1 = DBManager.countLaunchPlay1 - DBManager.score1Player;
        score2 = DBManager.score2Player;
        countLaunchGame2 = DBManager.countLaunchPlay2;
        correctLaunchGame2 = DBManager.score2Player;
        incorrectLaunchGame2 = DBManager.countLaunchPlay2 - DBManager.score2Player;
    }
}
