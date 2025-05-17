using System;
using TMPro;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeText;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnLifeUpdate += OnLifeUpdate;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnLifeUpdate -= OnLifeUpdate;
        }
    }

    private void OnLifeUpdate(int life)
    {
        if (lifeText != null)
        {
            lifeText.text = life.ToString();
        }
    }
}