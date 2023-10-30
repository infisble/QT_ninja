using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject male;
    public GameObject female;

    public void SceneTransition()
    {
        GameObject activeObject = null;

        if (male.activeSelf)
        {
            activeObject = male;
        }
        else if (female.activeSelf)
        {
            activeObject = female;
        }

        if (activeObject != null)
        {
            DontDestroyOnLoad(activeObject);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
