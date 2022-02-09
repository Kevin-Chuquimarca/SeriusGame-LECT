using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class DBManager : MonoBehaviour
{
    public InputField textName;
    public static string namePlayer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void send(){
        namePlayer = textName.text;
        sendPortPost();
    }

    public void sendPortPost(){
        User user = new User();
        RestClient.Post("https://cooltowaystomanagewaste-default-rtdb.firebaseio.com/.json", user);
    }
}
