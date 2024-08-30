using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] private TextMeshProUGUI TextLife;
    [SerializeField] private GameObject panelWinOrLose;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private TextMeshProUGUI TextResult;
    [SerializeField] private TextMeshProUGUI AnotherTime;
    [SerializeField] private GameObject buttonP;

    private float time;
    private float timeSpeed = 2.0f;
    private bool finish = false;

    private void Update()
    {
        if(TextTime != null)
        {
            time += Time.deltaTime * timeSpeed;
            TextTime.text = "Tiempo " + time.ToString("F2");

        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        if (buttonP != null)
        {
            buttonP.SetActive(false);
            panelPause.SetActive(true);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        if (buttonP != null)
        {
            buttonP.SetActive(true);
            panelPause.SetActive(false);

        }
    }
    public void TextLifeUpdate(int vida)
    {
        if (TextLife != null)
        {
            TextLife.text = "Vida: " + vida;
        }
    }

    public void EndLevel(bool ending)
    {
        finish = true;
        Time.timeScale = 0f;

        if (ending)
        {
            TextResult.text = " GANASTE ";
        }
        else
        {
            TextResult.text = "PERDISTE";
        }

        AnotherTime.text = TextTime.text;

        panelWinOrLose.SetActive(true);
    }
}