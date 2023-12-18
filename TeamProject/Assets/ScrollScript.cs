using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    ScrollLogicScript scr;

    [SerializeField] private AudioSource collectionSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        scr = gameObject.GetComponentInParent<ScrollLogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameLogicScript.Instance.Score += 2;
        gameObject.SetActive(false);
        scr.ScrollCount++;
        collectionSoundEffect.Play();
    }
}
