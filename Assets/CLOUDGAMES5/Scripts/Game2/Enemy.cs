using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ColorData enemyColor;
    [SerializeField] private int damage = 2;

    public static event Action<ColorData, int> OnEnter;
    public static event Action OnExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnter?.Invoke(enemyColor, damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnExit?.Invoke();
        }
    }
}