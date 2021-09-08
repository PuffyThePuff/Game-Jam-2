using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    private Vector3 spawnPos;
    private FunctionTimer functionTimer;

    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int maxObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = this.GetComponent<Transform>().position;
        functionTimer = new FunctionTimer(SpawnObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        functionTimer.Update();
    }

    private void SpawnObject()
    {
        Instantiate(objectToSpawn);
        objectToSpawn.transform.position = spawnPos;
        objectToSpawn.SetActive(true);
    }
}
