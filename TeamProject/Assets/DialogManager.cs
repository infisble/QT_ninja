using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public PlayerScript playerScript;
	public GameObject DialogTextBox;

	private List<Image> _selectedPointers = new();
	private List<Text> _possibleAnswers = new();
	private Text _question;

	private int _selectedIdx = 0;
	private int _correctIdx;

	private bool _isTalking = false;


	// Start is called before the first frame update
	void Start()
    {
		SetTextVariables();
		DialogTextBox.SetActive(false);
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update()
    {
		if (!_isTalking) return;
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			SetTalkingState(false);
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			SelectPreviousOption();
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			SelectNextOption();
		}
    }

	public void StartDialog(string question, string[] values, int correctAnswerIdx = 0)
	{
		/// This method is called when you want to display DialogText
		_correctIdx = correctAnswerIdx;
		_selectedIdx = 0;
		//SetTextVariables();		// ?
		SetDialogTextOptions(question,values);
		SetTalkingState(true);
		SelectOption(_selectedIdx);
	} 

	private void SetTextVariables()
	{
		var textFields = DialogTextBox.GetComponentsInChildren<Text>();
		int i = 0;
		foreach (var text in textFields)
		{
			// First text component is always Question
			if (i == 0)
			{
				_question = text;
			}
			else
			{
				_possibleAnswers.Add(text);
			}
			i++;
		}

		foreach (var answer in _possibleAnswers)
		{
			_selectedPointers.Add(answer.GetComponentInChildren<Image>());
		}
		Debug.Log(_possibleAnswers.Count);
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

	private void SetDialogTextOptions(string question, string[] values)
	{
		//Debug.Log(_possibleAnswers.Count);

		if (values.Length != 3)
		{
			throw new ArgumentException("Values array must have length 3");
		}

		_question.text = question;
		for (int i = 0; i< values.Length; i++)
		{
			_possibleAnswers[i].text = values[i];
		}
	}

	private void SelectOption(int selectIdx)
	{
		for (int i = 0; i < _possibleAnswers.Count; i++)
		{
			if (i == selectIdx) _selectedPointers[i].enabled = true;
			else _selectedPointers[i].enabled = false;
		}
	}

	private void SelectPreviousOption()
	{
		if (_selectedIdx == 0)
		{
			_selectedIdx = 2;
		}
		else --_selectedIdx;

		SelectOption(_selectedIdx);
	}
	private void SelectNextOption()
	{
		_selectedIdx = ++_selectedIdx % 3;

		SelectOption(_selectedIdx);
	}
}
