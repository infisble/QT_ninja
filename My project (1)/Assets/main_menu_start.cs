using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class main_menu_start : MonoBehaviour
{
    public void playGame(){

SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}

public void exit(){
Application.Quit();


}



}
