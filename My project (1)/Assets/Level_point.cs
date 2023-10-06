using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level_point : MonoBehaviour
{
    public void Green_lewel(){
    SceneManager.LoadScene("Battle_level_03");
    }
    public void Red_lewel(){
    SceneManager.LoadScene("Battle_level_01");
    }
    public void Blue_lewel(){
    SceneManager.LoadScene("Battle_level_02");
    }
    
    public void LostMenu(){


Time.timeScale = 1f;
SceneManager.LoadScene("Main_Game_Menu");

}
}
