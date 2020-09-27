using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePlayerCtrl : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;
    Animator anim;

    float rotateDegree;
    Vector3 mousePosition;
    Vector3 target;
    Vector3 moveDir;

    public float speed = 10.0f;

    public Transform firePos;
    public GameObject bullet;
    bool fireReady = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        moveDir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Attack();
    }

    private void Move()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        rb.velocity = moveDir * speed;

        if (moveDir.normalized != Vector3.zero)
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }

    }
    void Rotate()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            tr.LookAt(new Vector3(pointToLook.x, tr.position.y, pointToLook.z));
        }
    }
    void Attack()
    {
        if (Input.GetMouseButton(0) && fireReady)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        fireReady = false;
        Instantiate(bullet, firePos.position, firePos.rotation);
        yield return new WaitForSeconds(0.2f);
        fireReady = true;
    }
}
