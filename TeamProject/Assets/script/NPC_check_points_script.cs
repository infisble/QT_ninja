using UnityEngine;

public class NPC_check_points_script : MonoBehaviour
{
	public GameObject TalkButtonHint;
	public DialogManager DialogManager;
	public bool EnableGreeting;

    public string GreetingText;

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
			int npcsAnswered = GameLogicScript.Instance.CheckNPCS();
			int score = GameLogicScript.Instance.Score;

			if (EnableGreeting)
			{
				EnableGreeting = false;
				DialogManager.StartDialog(GreetingText);
				return;
			}
			
			string questionString;

			if (npcsAnswered < 5)
			{
				questionString = $"Zodpovedal si {GameLogicScript.Instance.CheckNPCS() * 5}/25 otazok. Zatiaľ si získal {score}/100 bodov.\n" +
					"Dokonči všetky otázky a potom sa vráť!.\n" +
					"Stlač <medzerník> pre pokračovanie";
			}
			else
			if (score >= 56)
			{
				questionString = $"Zodpovedal si všetky otázky. Získal si {score}/100 bodov. To je dostatok pre postup do ďalšej úrovne!\n" +
								 "Stlač <medzerník> pre postup do ďaľšej úrovne";
				DialogManager.LevelAdvancementCheck = true;
			} else
			{
				questionString = $"Máš {score}/100 bodov. To je málo pre postup do ďaľšej úrovne. Budeš to musieť skúsiť znova!\n" +
								 "Stlač <medzerník> pre reštartovanie";
				DialogManager.LevelAdvancementCheck = true;
			}

			DialogManager.StartDialog(questionString);
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