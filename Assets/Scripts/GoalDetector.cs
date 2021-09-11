using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onAntReachGoal += OnAntReachGoal;
    }

    private void OnAntReachGoal()
    {
        //update UI here
    }
}
