using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    float RandX;
    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 2f;
    float nextSpawn = 0.0f;
    float timeElapsed = 0.0f;

    void Update()
    {
        if (timeElapsed < 120f) 
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                RandX = Random.Range(-9f, 9f);
                whereToSpawn = new Vector2(RandX, transform.position.y);
                Instantiate(obj, whereToSpawn, Quaternion.identity);
            }

            timeElapsed += Time.deltaTime;
        }
        else
        {
           
            SceneManager.LoadScene("Start_house");
        }
    }
}
