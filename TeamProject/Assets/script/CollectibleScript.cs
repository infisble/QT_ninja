using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JsonReader;

public class CollectibleScript : MonoBehaviour
{
	public GameObject InteractPopup;

	private bool _canInteract;

    // Start is called before the first frame update
    void Start()
    {
		InteractPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (_canInteract && Input.GetKeyDown(KeyCode.E))
		{
			gameObject.SetActive(false);
			GameLogicScript.Instance.IncrementScore(2);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		InteractPopup.SetActive(true);
		_canInteract = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		InteractPopup.SetActive(false);
		_canInteract = false;
	}
}
