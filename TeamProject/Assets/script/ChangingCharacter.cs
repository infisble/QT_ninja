using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCharacter : MonoBehaviour
{
    public SpriteRenderer[] hairs;
    public SpriteRenderer hair;

    public SpriteRenderer[] skinsL;
    public SpriteRenderer skinLighter;

    public SpriteRenderer[] skinsD;
    public SpriteRenderer skinDarker;

    public GameObject[] mainBody;
    private int bodyIndex;

    public Color[] hairColors;
    public Color[] skinColors;
    public Color[] skinShadowedColors;

    public int hairColor = 0;
    public int skinColor = 0;

    private void Start()
    {
        bodyIndex = 0;
        mainBody[bodyIndex].SetActive(true);
        SetHairColor(bodyIndex);
        SetSkinColor(bodyIndex);
    }
    void Update()
    {
        SetHairColor(bodyIndex);
        SetSkinColor(bodyIndex);
    }

    void SetHairColor(int indx)
    {
        hair = hairs[indx];
        for (int i = 0; i < hairColors.Length; i++)
        {
            if (i == hairColor)
            {
                hair.color = hairColors[i];
            }
        }
    }

    void SetSkinColor(int indx)
    {
        skinLighter = skinsL[indx];
        skinDarker = skinsD[indx];
        for (int i = 0; i < skinColors.Length; i++)
        {
            if (i == skinColor)
            {
                skinLighter.color = skinColors[i];
                skinDarker.color = skinShadowedColors[i];
            }
        }
    }

    public void ChangeHairColor()
    {
        if (hairColor == hairColors.Length - 1)
        {
            hairColor = 0;
        }
        else { hairColor++; }
    }

    public void ChangeSkinColor()
    {
        if (skinColor == skinColors.Length - 1)
        {
            skinColor = 0;
        }
        else { skinColor++; }
    }

    public void ChangeGender()
    {
        mainBody[bodyIndex].SetActive(false);
        bodyIndex = (bodyIndex + 1) % mainBody.Length;
        mainBody[bodyIndex].SetActive(true);
    }
}
