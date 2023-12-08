using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasePosition : MonoBehaviour
{
    bool isSeen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isSeen = true;
            Seen();
            Debug.Log("Vase seen");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isSeen = false;
        }
    }

    private void Seen()
    {
        Janitor.Instance.Increment(1);
    }
}
