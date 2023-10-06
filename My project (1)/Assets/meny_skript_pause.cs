using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class meny_skript_pause : MonoBehaviour
{
    public bool PauseMenuGame;
    public GameObject pause_game_menu;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
         if(PauseMenuGame){

      Resume();
    }
else{

    Pause();
} } }

public void Resume(){
pause_game_menu.SetActive(false);
Time.timeScale = 1f;
PauseMenuGame = false;
}

public void Pause()
{
pause_game_menu.SetActive(true);
Time.timeScale = 0f;
PauseMenuGame = true;
}
public void LostMenu()
{
Time.timeScale = 1f;
SceneManager.LoadScene("Main_Game_Menu");
}




}
