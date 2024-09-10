using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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
           // targetSprite.color = buttonImage.color;
            targetSprite.tag = this.tag;
        }
    }

    public void OnChangeColor(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard != null)
            {
                if (keyboard.yKey.isPressed)
                {
                    targetSprite.color = Color.red;
                }
                else if (keyboard.uKey.isPressed)
                {
                    targetSprite.color = Color.green;
                }
                else if (keyboard.iKey.isPressed)
                {
                    targetSprite.color = Color.cyan;
                }
                else if (keyboard.oKey.isPressed)
                {
                    targetSprite.color = new Color(255f, 0f, 188f);
                }
            }
        }
    }
}