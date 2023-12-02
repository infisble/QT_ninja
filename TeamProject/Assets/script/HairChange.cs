using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairChange : MonoBehaviour
{
    public Sprite[] hairSprites;
    private int currentHairIndex;

    public SpriteRenderer hairRenderer;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHairIndex = PlayerPrefs.GetInt("HairIndex", 0);
        anim.SetInteger("order", currentHairIndex);
        Debug.Log("Start: " + currentHairIndex);
    }

    public void ChangeHair()
    {
        if (hairSprites.Length > 0)
        {
            currentHairIndex = (currentHairIndex + 1) % hairSprites.Length;
            hairRenderer.sprite = hairSprites[currentHairIndex];
            anim.SetInteger("order", currentHairIndex);
            Debug.Log("Click: " + currentHairIndex);
        }
    }
}
