using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSky : MonoBehaviour
{
    public float speed = 1.5f;

    private void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}
