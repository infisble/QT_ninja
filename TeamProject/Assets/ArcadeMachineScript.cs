using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeMachineScript : MonoBehaviour
{
    public GameObject TalkButtonHint;
    public string SceneName;
    private bool _isTalkable;

    public bool CanBeInteracted = false;

    private bool _isFinished;

    private void Start()
    {
        TalkButtonHint.SetActive(false);
    }

    private void Update()
    {
        if (_isTalkable && Input.GetKeyDown(KeyCode.E) && !_isFinished && CanBeInteracted)
        {
            if (gameObject.scene.name == "Level1") PlayerPrefs.SetInt("Level1", GameLogicScript.Instance.Score);
            if (gameObject.scene.name == "Level2") PlayerPrefs.SetInt("Level2", GameLogicScript.Instance.Score);
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isFinished || !CanBeInteracted) return;

        _isTalkable = true;
        TalkButtonHint.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        _isTalkable = false;
        TalkButtonHint.SetActive(false);
    }
}
