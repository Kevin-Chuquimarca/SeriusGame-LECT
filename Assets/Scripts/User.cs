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
    public User(){
        nameUser = DBManager.namePlayer;
        score1 = DBManager.score1Player;
        score2 = DBManager.score2Player;
    }
}
