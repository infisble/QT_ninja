using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JsonReader;

public class BonusBookScript : MonoBehaviour
{
    bool _isPickable = false;
    // Update is called once per frame
    void Update()
    {
        if (_isPickable && Input.GetKeyDown(KeyCode.E))
        {
            GameLogicScript.Instance.IncrementScore(2);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isPickable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isPickable = false;
    }
}
