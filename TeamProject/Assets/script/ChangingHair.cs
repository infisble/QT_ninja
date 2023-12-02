using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingHair : MonoBehaviour
{
    public SpriteRenderer hairM;
    public SpriteRenderer hairF;
    public Sprite[] options;
    public int index;

    void Update()
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (i == index)
            {
                hairM.sprite = options[i];
                hairF.sprite = options[i];
            }
        }
    }

    public void Swap()
    {
        if (index < options.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
        PlayerPrefs.SetInt("HairIndex", index);
        PlayerPrefs.Save();
    }
}
