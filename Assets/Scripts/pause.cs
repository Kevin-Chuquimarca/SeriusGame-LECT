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
}
