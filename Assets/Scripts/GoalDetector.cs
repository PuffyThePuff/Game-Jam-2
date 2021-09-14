using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDetector : MonoBehaviour
{
    private Text text;
    [SerializeField] private int antMax;
    private int antCurrent;
    private int antInGoal = 0;
    private int antLeft;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        antCurrent = antMax;
        antLeft = antMax;
        string newText;
        newText = "Ants: " + antCurrent + "/" + antMax;
        text.text = newText;
        GameEvents.current.onAntDeath += OnAntDeath;
        GameEvents.current.onAntReachGoal += OnAntReachGoal;
    }

    private void OnAntDeath()
    {
        antCurrent--;
        antLeft--;
        string newText;
        newText = "Ants left: " + antCurrent + "/" + antMax;
        text.text = newText;
        if (antLeft <= 0 && antInGoal < 1)
        {
            GameEvents.current.GameOver();
        }
    }

    private void OnAntReachGoal()
    {
        antInGoal++;
        antLeft--;
        if (antLeft <= 0 && antInGoal > 0)
        {
            GameEvents.current.LevelComplete();
        }
    }
}
