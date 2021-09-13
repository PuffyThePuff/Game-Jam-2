using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDetector : MonoBehaviour
{
    private Text text;
    [SerializeField] private int antMax;
    private int antCurrent;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        antCurrent = antMax;
        string newText;
        newText = "Ants: " + antCurrent + "/" + antMax;
        text.text = newText;
        GameEvents.current.onAntDeath += OnAntDeath;
    }

    private void OnAntDeath()
    {
        antCurrent--;
        string newText;
        newText = "Ants left: " + antCurrent + "/" + antMax;
        text.text = newText;
        if (antCurrent <= 0)
        {
            GameEvents.current.GameOver();
        }
    }
}
