using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onAntReachGoal;
    public void AntReachGoal()
    {
        if (onAntReachGoal != null)
        {
            onAntReachGoal();
        }
    }

    public event Action onAntDeath;
    public void AntDeath()
    {
        if (onAntDeath != null)
        {
            onAntDeath();
        }
    }

    public event Action onGameOver;
    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }

    public event Action onLevelComplete;
    public void LevelComplete()
    {
        if (onLevelComplete != null)
        {
            onLevelComplete();
        }
    }
}
