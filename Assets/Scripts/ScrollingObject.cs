using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private float speed = 0;

    private void Update()
    {
        if(!GameManager.instance.isGameover)
        {
            speed = 3 + Time.deltaTime * 0.1f;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
          
    }
}
