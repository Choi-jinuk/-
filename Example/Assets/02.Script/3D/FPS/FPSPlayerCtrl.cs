using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerCtrl : MonoBehaviour
{
    Transform tr;
    CharacterController controller;
    Vector3 MoveDir;
    float yRotate;

    bool bulletReady = true;

    public GameObject bullet;
    public Transform firePos;
    public Transform playerCamera;

    public float jumpSpeed = 2.0f;
    public float speed = 4.0f;
    public float gravity = 20.0f;
    public float rotSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        tr = GetComponent<Transform>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Attack();
    }
    void Move()
    {
        if (controller.isGrounded)
        {
            MoveDir.x = Input.GetAxis("Horizontal");
            MoveDir.z = Input.GetAxis("Vertical");

            MoveDir = transform.TransformDirection(MoveDir);
            if (Input.GetButton("Jump"))
            {
                MoveDir.y = jumpSpeed;
            }
        }
        MoveDir.y -= gravity * Time.deltaTime;
        controller.Move(MoveDir * Time.deltaTime * speed);
    }
    void Rotate()
    {
        tr.Rotate(Vector3.up*Input.GetAxis("Mouse X")*rotSpeed);
        yRotate += Input.GetAxis("Mouse Y") * -1;
        yRotate = Mathf.Clamp(yRotate, -27f, 5f);
        playerCamera.transform.localRotation = Quaternion.Euler(yRotate, 0f, 0f);
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && bulletReady)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        bulletReady = false;
        Instantiate(bullet, firePos);
        yield return new WaitForSeconds(1.0f);
        bulletReady = true;
    }
}
