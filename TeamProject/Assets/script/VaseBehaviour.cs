using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseBehaviour : MonoBehaviour
{
    bool isNear = false;
    private Transform vase;
    public GameObject[] positions;

    void Start()
    {
        vase = GetComponent<Transform>();
        Debug.Log("Vase op:" + vase.position);

        for(int i = 0; i < positions.Length; i++)
        {
            if(vase.position != positions[i].transform.position)
            {
                positions[i].SetActive(false);
            }
        }
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
        for (int j = 0; j < positions.Length; j++)
        {
            if (vase.position == positions[j].transform.position)
            {
                positions[j].SetActive(false);
            }
        }
        int i = Random.Range(0, 6);
        if(vase.position == positions[i].transform.position)
        {
            Teleport();
        }
        else
        {
            vase.position = positions[i].transform.position;
            positions[i].SetActive(true);
            Debug.Log("Vase cp:" + vase.position);
            Janitor.Instance.Increment(0);
        }
    }
}
