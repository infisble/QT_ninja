using UnityEngine;

public class NPC_check_points_script : MonoBehaviour
{
	public GameObject TalkButtonHint;
	public DialogManager DialogManager;

	private bool _isTalkable;

	private void Start()
	{
		TalkButtonHint.SetActive(false);
	}

	private void Update()
	{
		if (_isTalkable && Input.GetKeyDown(KeyCode.E))
		{
			TalkButtonHint.SetActive(false);

			string questionString;
			if (GameLogicScript.Instance.Score >= 56)
			{
				questionString = $"Máš {GameLogicScript.Instance.Score}/100 bodov. To je dostatok pre postup do ďaľšej úrovne!\n" +
								 "Stlač <medzerník> pre postup do ďaľšej úrovne";
			} else
			{
				questionString = $"Máš {GameLogicScript.Instance.Score}/100 bodov. To je málo pre postup do ďaľšej úrovne. Budeš to musieť skúsiť znova!\n" +
								 "Stlač <medzerník> pre reštartovanie";
			}

			DialogManager.StartDialog(questionString);
			DialogManager.LevelAdvancementCheck = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		TalkButtonHint.SetActive(true);
		_isTalkable = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		TalkButtonHint.SetActive(false);
		_isTalkable = false;
	}
}