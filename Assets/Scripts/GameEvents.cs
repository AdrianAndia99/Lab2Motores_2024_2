using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<int> OnLifeUpdated;
    public static event Action<int> OnScoreUpdated;
    public static event Action<bool> OnGameEnd;

    public static void LifeUpdated(int newLife)
    {
        OnLifeUpdated?.Invoke(newLife);
    }

    public static void ScoreUpdated(int newScore)
    {
        OnScoreUpdated?.Invoke(newScore);
    }

    public static void GameEnd(bool victory)
    {
        OnGameEnd?.Invoke(victory);
    }
}