using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluppyBirdCtrl : MonoBehaviour
{
    Rigidbody2D rb;

    public float upPower;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * upPower);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Scenery": Time.timeScale = 0f; break;
            case "Score": FluppyBirdColumnCtrl.Instance.ChangeColumn(collision.gameObject); break;
        }
    }
}
