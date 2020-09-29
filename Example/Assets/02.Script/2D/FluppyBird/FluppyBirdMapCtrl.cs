using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluppyBirdMapCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D groundCollider;
    float groundHorizontalLength;

    public float scrollSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * scrollSpeed;

        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            Repeat();
        }
    }
    void Repeat()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
