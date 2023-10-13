using UnityEngine;
using UnityEngine.UI;

public class eettt : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private Image img;

    [Header("Sprites")]
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
[SerializeField] private SpriteRenderer spriterend;
    private string spriteKey = "SelectedSprite";

    private void Start()
    {
        // Load the last selected sprite from PlayerPrefs when the game starts.
        int savedSpriteIndex = PlayerPrefs.GetInt(spriteKey); // 0 is the default value if the key doesn't exist.

        // Set the initial sprite based on the saved index.
        SetSprite(savedSpriteIndex);
    }

    public void ChangeSpriteBlue()
    {
        SetSprite(0); // 0 corresponds to sprite1
    }

    public void ChangeSpriteRed()
    {
        SetSprite(1); // 1 corresponds to sprite2
    }

    public void ChangeSpriteGreen()
    {
        SetSprite(2); // 2 corresponds to sprite3
    }

    private void SetSprite(int spriteIndex)
    {
        switch (spriteIndex)
        {
            case 0:
                img.sprite = sprite1;
                spriterend.sprite = sprite1;
                break;
            case 1:
                img.sprite = sprite2;
                 spriterend.sprite = sprite2;
                break;
            case 2:
                img.sprite = sprite3;
                spriterend.sprite = sprite3;
                break;
        }

        // Save the selected sprite index to PlayerPrefs.
        PlayerPrefs.SetInt(spriteKey, spriteIndex);
        PlayerPrefs.Save(); // This line is optional, but it's a good practice to ensure PlayerPrefs data is saved immediately.
    }
}