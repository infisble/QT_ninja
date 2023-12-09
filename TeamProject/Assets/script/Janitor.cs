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
    private bool mission1Finished = false;
    private bool mission2Finished = false;
    private bool mission3Finished = false;

    public GameObject vase;
    public GameObject pos;
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
            if (gameObject.scene.name == "Level3")
            {
                Level3Mission();
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
        if (mission1Finished)
        {
            DialogManager.StartDialog("Ďakujem za pomoc.");
            return;
        }

        string textString;
        textString = $"Zdravím. Potreboval by som vašu pomoc. Som tu nový a predchádzajúci školník" +
            $" nevrátil veci na miesto. Našli by ste mi ich prosím? Ak ich nájdete, prídte za mnou.";
        if (missionObjects == 3)
        {
            mission1Finished = true;
            textString = $"Ďakujem vám veľmi pekne. Za vašu pomoc som vám už vybavil 10 bodov.";
            GameLogicScript.Instance.IncrementScore(10);
        }

        DialogManager.StartDialog(textString);
    }

    private void Level2Mission()
    {
        if (mission2Finished)
        {
            DialogManager.StartDialog("Ďakujem za pomoc.");
            return;
        }
        string textString;
        textString = $"Zdravím. Opäť by som potreboval vašu pomoc. Škola kúpila automat na kávu" +
            $" a teraz sú všade porozhadzované poháre. Ja musím ísť riešiť niečo iné," +
            $" tak ak by ste uvideli niekde pohodený pohár, zahodili by ste ho? Prídte za mnou, keď ich upracete.";
        if (missionObjects == 6)
        {
            mission2Finished = true;
            textString = $"Ďakujem vám veľmi pekne. Za vašu pomoc som vám už vybavil 10 bodov.";
            GameLogicScript.Instance.IncrementScore(10);
        }

        DialogManager.StartDialog(textString);
    }

    private void Level3Mission()
    {
        if (mission3Finished)
        {
            DialogManager.StartDialog("Ďakujem za pomoc.");
            return;
        }
        string textString;
        textString = $"Zdravím. Potreboval by som od vás poslednú službu. Ak by ste náhodou" +
            $" narazili na peknú vázu, mohli by ste sa sem okamžite vrátiť a nahlásiť mi, na ktorom" +
            $" poschodí sa nachádza?";
        if (missionObjects == 1)
        {
            textString = $"Som vám nesmierne vďačný. Za vašu pomoc som vám už vybavil 10 bodov. Keďže toto bola" +
                $" životu nebezpečná úloha, poviem vám tajomstvo. Na 6.poschodí vľavo v knižnici nájdete knihu" +
                $" so všetkymi správnymi odpoveďami.";
            mission3Finished = true;
            vase.SetActive(false);
            pos.SetActive(false);
            GameLogicScript.Instance.IncrementScore(10);
        }
        DialogManager.StartDialog(textString);
    }

    public void Increment(int val)
    {
        missionObjects += val;
        if(gameObject.scene.name == "Level3")
        {
            missionObjects = val;
        }
        Debug.Log(missionObjects);
    }
}
