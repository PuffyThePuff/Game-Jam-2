using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    private Vector3 spawnPos;

    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int maxObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = this.GetComponent<Transform>().position;
        for (int i = 0; i < maxObjects; i++)
        {
            FunctionTimer.Create(SpawnObject, 2 * i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObject()
    {
        Instantiate(objectToSpawn);
        objectToSpawn.transform.position = spawnPos;
        objectToSpawn.SetActive(true);
    }
}
