using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : MonoBehaviour
{
    public static Janitor Instance { get; private set; }
    public GameObject TalkButtonHint;
    public DialogManager DialogManager;
    private bool playerIsClose;
    private int mission1Objects;
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
        mission1Objects = 0;
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
        textString = $"Zdravím. Potreboval by som vašu pomoc. Som tu nový a predchádzajúci školník" +
            $" nevrátil veci na miesto. Našli by ste mi ich prosím? Ak ich nájdete, prídte za mnou.";
        if (mission1Objects == 3)
        {
            textString = $"Ïakujem vám ve¾mi pekne. Za vašu pomoc som vám už vybavil 10 bodov.";
            GameLogicScript.Instance.IncrementScore(10);
        }

        DialogManager.StartDialog(textString);
    }

    public void Increment(int val)
    {
        mission1Objects += val;
        //Update();
    }
}
