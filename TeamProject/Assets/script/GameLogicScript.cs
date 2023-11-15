using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
	public static GameLogicScript Instance { get; private set; }
	public int Score = Instance is null ? 0 : Instance.Score;
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
		Score += 4;
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
			ScoreText.text = $"{Score}/100";
		}
	}
	
	public void AdvanceLevel()
	{
		if (Score < 56)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		} else
		{

		}
	}
}
