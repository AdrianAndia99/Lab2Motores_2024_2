using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class ColorPowerUpManager : MonoBehaviour
{
    [SerializeField] private ColorData[] colors;     
    [SerializeField] private ColorData currentColor; 

    private int _cont = 0;           
    private int _direction = 0;       
    private bool _canChange = true;

    public static event Action<ColorData> OnChangeColor; 

    private void OnEnable()
    {
        Enemy.OnEnter += ValidateCollision;  
        Enemy.OnExit += ReturnToNormal;
    }

    private void OnDisable()
    {
        Enemy.OnEnter -= ValidateCollision;
        Enemy.OnExit -= ReturnToNormal;
    }

    public void OnPreviousColor(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _direction = -1;
            ChangeColorSelection();
        }
    }

    public void OnNextColor(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _direction = 1;
            ChangeColorSelection();
        }
    }

    private void ChangeColorSelection()
    {
        if (!_canChange) return;

        _cont += _direction;

        if (_cont < 0)
        {
            _cont = colors.Length - 1;
        }
        else if (_cont >= colors.Length)
        {
            _cont = 0;
        }

        currentColor = colors[_cont];
        OnChangeColor?.Invoke(currentColor);
    }

    private void ValidateCollision(ColorData enemyColor, int damage)
    {
        if (enemyColor.color != currentColor.color)
        {
            GameManager.Instance.ModifyLife(-damage);
            _canChange = false;
        }
    }

    private void ReturnToNormal()
    {
        _canChange = true;
    }
}