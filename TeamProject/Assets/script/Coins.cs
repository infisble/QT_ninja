using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoneyText.Coin += 1;
            Destroy(gameObject);
 if (MoneyText.Coin == 10)
        {
            SceneManager.LoadScene("Start_house");
        }
           
        }

        if (collision.CompareTag("Destr"))
        {
            Destroy(gameObject);
        }
    }
}
