using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollLogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int ScrollCount = 0;

    private const int _maxScrolls = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScrollCount >= _maxScrolls)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
