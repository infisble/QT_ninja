using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : MonoBehaviour
{
    public static Janitor Instance { get; private set; }
    public GameObject TalkButtonHint;
    public DialogManager DialogManager;
    private bool playerIsClose;
    private int missionObjects;
    // Start is called before the first frame update
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
        TalkButtonHint.SetActive(false);
        missionObjects = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            TalkButtonHint.SetActive(false);
            if (gameObject.scene.name == "Level1")
            {
                Level1Mission();
            }
            if (gameObject.scene.name == "Level2")
            {
                Level2Mission();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
            TalkButtonHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            TalkButtonHint.SetActive(false);
        }
    }

    private void Level1Mission()
    {
        string textString;
        textString = $"ZdravÌm. Potreboval by som vaöu pomoc. Som tu nov˝ a predch·dzaj˙ci ökolnÌk" +
            $" nevr·til veci na miesto. Naöli by ste mi ich prosÌm? Ak ich n·jdete, prÌdte za mnou.";
        if (missionObjects == 3)
        {
            textString = $"œakujem v·m veæmi pekne. Za vaöu pomoc som v·m uû vybavil 10 bodov.";
            GameLogicScript.Instance.IncrementScore(10);
        }

        DialogManager.StartDialog(textString);
    }

    private void Level2Mission()
    {
        string textString;
        textString = $"ZdravÌm. Op‰ù by som potreboval vaöu pomoc. äkola k˙pila automat na k·vu" +
            $" a teraz s˙ vöade porozhadzovanÈ poh·re. Ja musÌm Ìsù rieöiù nieËo inÈ," +
            $" tak ak by ste uvideli niekde pohoden˝ poh·r, zahodili by ste ho? PrÌdte za mnou hneÔ ako ich upracete.";
        if (missionObjects == 6)
        {
            textString = $"œakujem v·m veæmi pekne. Za vaöu pomoc som v·m uû vybavil 10 bodov.";
            GameLogicScript.Instance.IncrementScore(10);
        }

        DialogManager.StartDialog(textString);
    }

    public void Increment(int val)
    {
        missionObjects += val;
    }
}
