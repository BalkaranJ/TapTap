using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{

    public GameObject circlePrefab;
    public float spawnInterval = 1f;
    public float spawnDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCircle", 1f, spawnInterval);
    }

    void SpawnCircle()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + spawnDistance, Random.Range(-4f, 4f), 0);
        Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
    }
}
