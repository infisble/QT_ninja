using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_buttn : MonoBehaviour
{
    public void playGame()
    {
        PlayerPrefs.SetInt("HairIndex", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exit()
    {
        Application.Quit();
    }
}

