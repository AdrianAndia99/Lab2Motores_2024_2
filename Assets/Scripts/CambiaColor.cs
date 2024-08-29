using UnityEngine;
using UnityEngine.UI;

public class CambiaColor : MonoBehaviour
{
    public SpriteRenderer targetSprite; 
    private Button button;
    private Image buttonImage;

    void Start()
    {
        button = GetComponent<Button>();

        buttonImage = button.GetComponent<Image>();

        button.onClick.AddListener(ChangeSpriteColor);
    }

    void ChangeSpriteColor()
    {
        if (targetSprite != null && buttonImage != null)
        {
            targetSprite.color = buttonImage.color;
            targetSprite.tag = this.tag;
        }
    }
}