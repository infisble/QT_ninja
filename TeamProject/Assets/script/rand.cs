using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    private int chosenIndex;
    public GameObject[] spawnableObjects;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnableObjects.Length > 0)
        {
            chosenIndex = Random.Range(0, spawnableObjects.Length);
            Instantiate(spawnableObjects[chosenIndex], transform.position, Quaternion.identity);
            Destroy(gameObject); // Optional: destroy the current GameObject if needed
        }
        else
        {
            Debug.LogError("No spawnable objects assigned to the array. Please assign objects in the Unity Editor.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can add update logic here if needed
    }
}
