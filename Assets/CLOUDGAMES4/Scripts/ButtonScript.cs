using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float targetScale = 2f;
    public float duration = 0.2f;

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(targetScale, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(initialScale, duration);
    }
}