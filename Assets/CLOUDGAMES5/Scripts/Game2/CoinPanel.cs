using System;
using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    private void OnEnable()
    {
        GameManager.Instance.OnCoinUpdate += OnCoinUpdate;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinUpdate -= OnCoinUpdate;        
    }

    private void OnCoinUpdate(int coins)
    {
        coinText.text = coins.ToString();
    }
}