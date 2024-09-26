using UnityEngine;
using UnityEngine.UI;
public class RandomButtonScale : MonoBehaviour
{
    public Button button;        
    public float minScale = 0.5f; 
    public float maxScale = 1.5f; 
    public float interval = 2f;   

    private RectTransform buttonRect;

    void Start()
    {
        buttonRect = button.GetComponent<RectTransform>();

        InvokeRepeating("RandomizeScale", 0f, interval);
    }

    void RandomizeScale()
    {
        float randomScale = Random.Range(minScale, maxScale);

        buttonRect.localScale = new Vector3(randomScale, randomScale, 1);
    }

    void OnDisable()
    {
        CancelInvoke("RandomizeScale");
    }
}