using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.CompareTag("Player"))
        {
            //MoneyText.Coin += 1;
            //PlayerPrefs.SetInt("coins", MoneyText.Coin);
            Destroy(gameObject);
        // Створіть екземпляр класу PlayerScript
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();

            // Перевірте, чи екземпляр не є нульовим перед доступом до speed
            if (playerScript != null)
            {
                playerScript.speed = 5f;
            }
        }
        if(collision.CompareTag("Destr"))
        {
            Destroy(gameObject);
        }
    }
}
