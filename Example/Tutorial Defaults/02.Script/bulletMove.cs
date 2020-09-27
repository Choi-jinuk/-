using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(1.0f, 0, 0) * 100.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //내가 지금 충돌을 한 애가 Enemy란 tag를 가지고 있냐
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            //액티브상태를 꺼주겠다는 뜻
            collision.collider.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
