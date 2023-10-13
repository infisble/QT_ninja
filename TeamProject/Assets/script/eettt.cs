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
        // Set the initial sprite based on the saved index.
		img.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString(spriteKey));
	}

    public void ChangeSpriteBlue()
    {
        SetSprite("pngegg (4)"); // 0 corresponds to sprite1
    }

    public void ChangeSpriteRed()
    {
        SetSprite("pngegg (3)"); // 1 corresponds to sprite2
    }

    public void ChangeSpriteGreen()
    {
        SetSprite("ground"); // 2 corresponds to sprite3
    }

    private void SetSprite(string path)
    {
		//string spritePath = "";		// will never be empty, initializing to "" because otherwise you get uninitialized error
		string spritePath = path;
		
		// set preview sprite
		img.sprite = Resources.Load<Sprite>(path);

		// Save path to PlayerPrefs
		PlayerPrefs.SetString(spriteKey, spritePath);
        PlayerPrefs.Save(); // This line is optional, but it's a good practice to ensure PlayerPrefs data is saved immediately.
    }
}