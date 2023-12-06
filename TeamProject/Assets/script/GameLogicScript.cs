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
		ScoreText = GameObject.FindWithTag("Score")?.GetComponent<Text>();
		Update();
	}

	public void IncrementScore()
	{
		ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
		Score += 2;
		Update();
	}

	public void SceneTransition()
	{
		DontDestroyOnLoad(Instance);
	}

	public void Update()
	{
		ScoreText = GameObject.FindWithTag("Score")?.GetComponent<Text>();
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
            if (gameObject.scene.name == "Level2")
            {
			    SceneManager.LoadScene("Level3");
            } else
			SceneManager.LoadScene("Level2");
		}
	}

	public int CheckNPCS()
	{
		// Checks how many npcs have answered all questions

		GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
		int _npcsAnswered = 0;
		
		foreach (var npc in npcs)
		{
			if (npc.GetComponent<NPC_Script>().QuestionsFinished) _npcsAnswered++;
		}

		return _npcsAnswered;
	}
}
