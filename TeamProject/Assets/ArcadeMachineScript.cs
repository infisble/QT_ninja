using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeMachineScript : MonoBehaviour
{
    public GameObject TalkButtonHint;
    public string SceneName;
    private bool _isTalkable;

    private bool _isFinished;

    private void Start()
    {
        TalkButtonHint.SetActive(false);
    }

    private void Update()
    {
        if (_isTalkable && Input.GetKeyDown(KeyCode.E) && !_isFinished)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isFinished) return;

        _isTalkable = true;
        TalkButtonHint.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTalkable = false;
        TalkButtonHint.SetActive(false);
    }
}
