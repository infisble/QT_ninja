using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamestop : MonoBehaviour
{
 
    private bool isPaused = false;

    // Викликається при натисканні на Button1
    public void PauseGame()
    {
        Time.timeScale = 0f; // Зупинити час гри
        isPaused = true;
    }

    // Викликається при натисканні на Button2
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Поновити час гри до звичайного
        isPaused = false;
    }
public void dell()
{ SceneManager.LoadScene("minigame");
 MoneyText.Coin = 0;

}
    // Метод для перевірки чи гра на паузі
    public bool IsGamePaused()
    {
        return isPaused;
    }
}
