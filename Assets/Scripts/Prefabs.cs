using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public GameObject[] obstacles;

    private void OnEnable()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }

        obstacles[Random.Range(0, 8)].SetActive(true);
    }
}
