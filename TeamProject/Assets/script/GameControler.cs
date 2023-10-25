using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public string sceneToLoad; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
