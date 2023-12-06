using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	private PlayerScript playerScript;
	public GameObject DialogTextBox;
	private GameLogicScript GameLogicScript;
	private GameObject _options;

	private List<Image> _selectedPointers = new();
	private List<Text> _possibleAnswers = new();
	private JsonReader.Question[] _questions;
	private int currentQuestionIdx;
	private Text _question;

	private int _selectedOptionIdx = 0;
	private int _selectedQuestionIdx = 0;
	private int _correctOptionIdx;

	private bool _isTalking = false;
	private bool _textOnlyDialog = false;

	public bool LevelAdvancementCheck = false;

	// Start is called before the first frame update
	void Start()
    {
		SetTextVariables();
		DialogTextBox.SetActive(false);
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
		GameLogicScript = GameLogicScript.Instance;
		_options = GameObject.FindWithTag("DialogOptions");
	}

	// Update is called once per frame
	void Update()
	{

		if (!_isTalking) return;
		
		if (!_textOnlyDialog)
		{
			// Select answer
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				// correct answer 
				if (_selectedOptionIdx == _correctOptionIdx) GameLogicScript.IncrementScore(4);

				// check if last question
				if (_selectedQuestionIdx < _questions.Length - 1) SelectQuestion(++_selectedQuestionIdx);
				else SetTalkingState(false);
			}
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				SelectPreviousOption();
			}
			if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				SelectNextOption();
			}
		} else
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				SetTalkingState(false);
				if (LevelAdvancementCheck)
				{
					LevelAdvancementCheck = false;
					GameLogicScript.Instance.AdvanceLevel();
				}
			}
		}
    }

	public void StartDialog(JsonReader.Subject subject)
	{
		if (_options is null) _options = GameObject.FindWithTag("DialogOptions");
		_options?.SetActive(true);
		_textOnlyDialog = false;
		currentQuestionIdx = 0;
		_questions = subject.Questions;
		SelectQuestion(currentQuestionIdx);
	}
	
	public void StartDialog(string text)
	{
		_textOnlyDialog = true;
		_question.text = text;
		SetTalkingState(true);
		if (_options is null) _options = GameObject.FindWithTag("DialogOptions");
		_options?.SetActive(false);
	}

	private void SelectQuestion(int idx)
	{
		var question = _questions[idx];
		_selectedQuestionIdx = idx;
		ShowQuestion(question.question, question.options, int.Parse(question.answer));
	}

	private void ShowQuestion(string question, string[] values, int correctAnswerIdx = 0)
	{
		/// This method is called when you want to display DialogText
		_correctOptionIdx = correctAnswerIdx;
		_selectedOptionIdx = 0;
		SetDialogTextOptions(question, values);
		SetTalkingState(true);
		SelectOption(_selectedOptionIdx);
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
		if (_selectedOptionIdx == 0)
		{
			_selectedOptionIdx = 2;
		}
		else --_selectedOptionIdx;

		SelectOption(_selectedOptionIdx);
	}
	private void SelectNextOption()
	{
		_selectedOptionIdx = ++_selectedOptionIdx % 3;

		SelectOption(_selectedOptionIdx);
	}
}
