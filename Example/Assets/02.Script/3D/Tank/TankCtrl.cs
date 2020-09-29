using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCtrl : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;
    float h = 0.0f;
    float v = 0.0f;
    bool readyFire = true;


    public float speed;
    public GameObject bullet;
    public Transform firePos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Attack();
    }
    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //Axis란 유니티툴 상단 메뉴바의 Edit > ProjectSettings > InputManager 부분에서 관리
        //Horizontal : left(-1), right(1) or a(-1), d(1)
        //Vertical :  down(-1), up(1) or s(-1), w(1)

        rb.AddRelativeForce(Vector3.forward * v * speed, ForceMode.Impulse);
        //Vector3.forward란 new Vector3(0,0,1)과 같은 의미
        //new의 경우 매 프레임 새로운 객체를 생성하므로 비효율적이므로 상수 사용

        //ForceMode
        //Force(질량 적용) 연속적인 힘을 가함
        //Impulse(질량 적용) 순간적인 힘을 가함
        //Acceleration(질량 무시) 연속적인 힘을 가함
        //VelocityChange(질량 무시) 순간적인 힘을 가함

        rb.AddRelativeTorque(Vector3.up * h * speed * 0.5f,ForceMode.Impulse);
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyFire)
        {
            readyFire = false;
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        Instantiate(bullet, firePos);
        yield return new WaitForSeconds(2.0f);
        readyFire = true;
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2.0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
