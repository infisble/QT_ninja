using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
	public PlayerScript playerScript;
	public GameObject DialogTextBox;

	private bool _isTalking = false;


	// Start is called before the first frame update
	void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isTalking)
		{
			SetTalkingState(false);
		}
    }

	public void StartDialog(string question, string[] values, int correctAnswerIdx = 0)
	{
		SetDialogTextOptions(question,values,correctAnswerIdx);
		SetTalkingState(true);
	}

	private void SetTalkingState(bool isTalking)
	{
		_isTalking = isTalking;
		if (isTalking)
		{
			playerScript.CanMove = false;
			DialogTextBox.SetActive(true);
		}
		else
		{
			playerScript.CanMove = true;
			DialogTextBox.SetActive(false);
		}
	}

	private void SetDialogTextOptions(string question, string[] values, int correctAnswerIdx=0)
	{
		if (values.Length != 3)
		{
			throw new ArgumentException("Values array must have length 3");
		}

		// set question text
		//var questionText = GameObject.FindWithTag("DialogTextBox.QuestionText").GetComponent<Text>();
		var textFields = DialogTextBox.GetComponentsInChildren<Text>();
		int i = 0;
		foreach (var text in textFields)
		{
			// First text component is always Question
			if (i == 0)
			{
				text.text = question;
			} else
			{
				var x = text.GetComponent<Text>();
				x.text = values[i++];
			}
		}
	}
}
