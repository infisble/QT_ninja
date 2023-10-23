using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
	private int _score = 0;
	public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
		ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void IncrementScore()
	{
		_score += 4;
		ScoreText.text = $"{_score}/100";
	}
}
