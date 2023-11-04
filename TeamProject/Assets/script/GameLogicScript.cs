using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
	public static GameLogicScript Instance { get; private set; }
	private int _score = Instance is null ? 0 : Instance._score;
	private Text ScoreText;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
			return;
		}
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
