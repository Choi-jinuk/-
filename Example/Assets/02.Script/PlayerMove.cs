using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform tr;
    Rigidbody rb;
    float h = 0.0f;
    float v = 0.0f;
    public float speed = 2.0f;
    public Transform firePos;
    public GameObject bullet;
    //총알로 쓸 프리팹
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //1.
        tr.Translate(new Vector3(h,0,v) * speed,Space.World);
        tr.Rotate(new Vector3(0, h, 0) * 10f,Space.Self);
        //2.
        //rb.AddForce(new Vector3(h, 0, v) * speed);
        //3.
        //rb.velocity = new Vector3(h,0,v) * speed;

        //키코드 스페이스가 눌리고 있는 와중에
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, firePos);
        }
    }
}
