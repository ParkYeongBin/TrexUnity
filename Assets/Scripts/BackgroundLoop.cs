using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float startPoint = 6.0f;
    public float lastPoint = -6.0f;
    public float height;

    void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        height = backgroundCollider.size.y;
    }

    void Update()
    {
        if(transform.position.x <= lastPoint)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(startPoint * 2, height);
        transform.position = (Vector2)transform.position + offset;
    }
}
