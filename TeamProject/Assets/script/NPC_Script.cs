using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Script : MonoBehaviour
{
	public string Subject;
	public GameObject TalkButtonHint;
	public DialogManager DialogManager;
	public bool QuestionsFinished = false;

	private bool _isTalkable;

	private void Start()
	{
		TalkButtonHint.SetActive(false);
	}

	private void Update()
	{
		if (Subject == "")
		{
			throw new UnassignedReferenceException("NPC_Script Must have 'Subject' assigned to work properly !");
		}

		if (_isTalkable && Input.GetKeyDown(KeyCode.E) && !QuestionsFinished)
		{
			var x = JsonReader.GetData(Subject);
			TalkButtonHint.SetActive(false);
			DialogManager.StartDialog(x);
			QuestionsFinished = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (QuestionsFinished) return;

		TalkButtonHint.SetActive(true);
		_isTalkable = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		TalkButtonHint.SetActive(false);
		_isTalkable = false;
	}
}