using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public void BackMenu ()
    {
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
}
