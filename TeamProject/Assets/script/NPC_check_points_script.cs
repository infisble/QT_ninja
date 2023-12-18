using UnityEngine;
using UnityEngine.SceneManagement;

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
				questionString = $"Zodpovedali ste {GameLogicScript.Instance.CheckNPCS() * 5}/25 otázok. Zatiaľ ste získali {score}/100 bodov.\n" +
					"Dokončite všetky otázky a potom sa vráťte!.\n" +
					"Stlačte <medzerník> pre pokračovanie";
			}
			else
			if (score >= 56)
			{
                if (gameObject.scene.name == "Level3")
                {
                    // Succesfully finished last level
                    questionString = $"Gratulujem vám. Dokončili ste bakalárske štúdium.\nLevel1 : {PlayerPrefs.GetInt("Level1")}/100\nLevel2 : {PlayerPrefs.GetInt("Level2")}/100\nLevel3 : {GameLogicScript.Instance.Score}/100";
                } else
                {
                    questionString = $"Zodpovedali ste všetky otázky. Získali ste {score}/100 bodov. To je dostatok pre postup do ďalšieho ročníka!\n" +
                                    "Pre postup do ďalšieho ročníka si zahrajte automat.";
                    var machine = GameObject.FindGameObjectWithTag("ArcadeMachine");
                    if (machine is not null)
                    {
                        machine.GetComponent<ArcadeMachineScript>().CanBeInteracted = true;
                    }
                }

            }
            else
			{
				questionString = $"Máte {score}/100 bodov. To je málo pre postup do ďalšieho ročníka. Budete to musieť skúsiť znova!\n" +
								 "Stlačte <medzerník> pre reštartovanie";
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