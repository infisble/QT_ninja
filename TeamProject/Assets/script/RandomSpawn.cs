using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToSpawn; // Змінено на List для приймання декількох об'єктів
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

                // Вибрати випадковий об'єкт для спавну зі списку
                GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];

                Instantiate(objectToSpawn, whereToSpawn, Quaternion.identity);
            }

            timeElapsed += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Start_house");
        }
    }
}
