using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorBonus : MonoBehaviour
{
    bool _isPickable = false;
    // Update is called once per frame
    void Update()
    {
        if (_isPickable && Input.GetKeyDown(KeyCode.E))
        {
            Janitor.Instance.Increment(1);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPickable = false;
        }
    }
}
