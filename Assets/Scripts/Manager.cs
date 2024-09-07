using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] private TextMeshProUGUI TextLife;
    [SerializeField] private TextMeshProUGUI TextScore;
    [SerializeField] private GameObject panelWinOrLose;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private TextMeshProUGUI TextResult;
    [SerializeField] private TextMeshProUGUI AnotherTime;
    [SerializeField] private GameObject buttonP;

    private int score = 0;
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
    private void OnEnable()
    {
        GameEvents.OnLifeUpdated += UpdateLifeUI;
        GameEvents.OnScoreUpdated += UpdateScoreUI;
        GameEvents.OnGameEnd += EndGame;
    }

    private void OnDisable()
    {
        GameEvents.OnLifeUpdated -= UpdateLifeUI;
        GameEvents.OnScoreUpdated -= UpdateScoreUI;
        GameEvents.OnGameEnd -= EndGame;
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
    private void UpdateLifeUI(int newLife)
    {
        TextLife.text = "Vida: " + newLife;
    }

    private void UpdateScoreUI(int newScore)
    {
        score += newScore;
        TextScore.text = "Puntos: " + score;
    }

    public void EndGame(bool victory)
    {
        panelWinOrLose.SetActive(true);
        TextResult.text = victory ? "¡GANASTE!" : "PERDISTE";
        Time.timeScale = 0f;
    }
}