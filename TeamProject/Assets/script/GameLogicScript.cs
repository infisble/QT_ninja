using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
	public static GameLogicScript Instance;
	private int _score = 0;
	public Text ScoreText;

    // Start is called before the first frame update
	public GameLogicScript()
	{
		Instance = this;
	}

    void Start()
    {
		ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
		Update();
	}

	public void IncrementScore()
	{
		ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
		_score += 4;
		Update();
	}

	public void SceneTransition()
	{
		DontDestroyOnLoad(Instance);
	}

	public void Update()
	{
		ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
		if (ScoreText != null)
		{
			ScoreText.text = $"{_score}/100";
		}
	}
}
