using UnityEngine;
using UnityEngine.UI;

public class ColorRandom : MonoBehaviour
{
    public Image image;
    public float changeInterval = 2f;

    private void Start()
    {
        InvokeRepeating("ChangeColor", 0f, changeInterval);
    }

    private void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        image.color = randomColor;
    }
}