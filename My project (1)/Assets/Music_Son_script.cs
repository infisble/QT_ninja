using UnityEngine;
using UnityEngine.UI;

public class Music_Son_ : MonoBehaviour
{
    bool a = true;

    [Header("Image")]
    [SerializeField] private Image img;

    [Header("Sprites")]
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    private void Start()
    {
        // При запуску гри спробуємо отримати значення a з PlayerPrefs
        // Якщо воно було збережено раніше, використаємо його, в іншому випадку залишимо значення за замовчуванням (true)
        if (PlayerPrefs.HasKey("a"))
        {
            a = PlayerPrefs.GetInt("a") == 1;
        }
        else
        {
            a = true;
        }

        UpdateImage();
    }

    public void Chang_sprite()
    {
        a = !a; // Змінюємо значення a на протилежне
        UpdateImage();
    }

    private void UpdateImage()
    {
        // Зберігаємо значення a в PlayerPrefs
        PlayerPrefs.SetInt("a", a ? 1 : 0);
        PlayerPrefs.Save();

        // Змінюємо спрайт в залежності від значення a
        img.sprite = a ? sprite1 : sprite2;
    }
}
