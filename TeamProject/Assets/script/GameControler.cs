using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public string sceneToLoad;

	private bool _canEnter;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (_canEnter) SceneManager.LoadScene(sceneToLoad);
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
    {
		_canEnter = true;
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		_canEnter = false;
	}
}
