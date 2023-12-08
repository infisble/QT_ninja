using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseBehaviour : MonoBehaviour
{
    bool isNear = false;
    private Transform vase;
    public Transform[] positions;
    // Start is called before the first frame update
    void Start()
    {
        vase = GetComponent<Transform>();
        Debug.Log("Vase op:" + vase.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNear = true;
            Debug.Log("Vase teleport");
            Teleport();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNear = false;
        }
    }

    private void Teleport()
    {
        int i = Random.Range(0, 6);
        vase.position = positions[i].position;
        Debug.Log("Vase cp:" + vase.position);
        Janitor.Instance.Increment(0);
    }
}
