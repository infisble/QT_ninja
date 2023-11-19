using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rand : MonoBehaviour
{
    private int rand_chose;
    public GameObject[] Choose_objects;

    // Start is called before the first frame update
    void Start()
    {
        rand_chose = Random.Range(0, Choose_objects.Length);
        Instantiate(Choose_objects[rand_chose], transform.position, Quaternion.identity);
        Destroy(gameObject); // Optional: destroy the current GameObject if needed
    }

    // Update is called once per frame
    void Update()
    {
        // You can add update logic here if needed
    }
}
