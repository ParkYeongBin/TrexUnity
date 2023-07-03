using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int count = 10;

    public float timeBetSpawnMin = 1.0f;
    public float timeBetSpawnMax = 4.0f;
    private float timeBetSpawn;

    public float xPos = 8f;
    public float yPos = -1;

    private GameObject[] obstacles;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(25, -1);
    private float lastSpawnTime;

    void Start()
    {
        obstacles = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab, poolPosition, Quaternion.identity);
            obstacles[i].SetActive(false);
        }

        lastSpawnTime = 0f;

        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover) return;

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            obstacles[currentIndex].SetActive(true);

            obstacles[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if (currentIndex >= count)
                currentIndex = 0;
        }
    }
}
