using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.AntDeath();
        other.gameObject.SetActive(false);
    }
}
