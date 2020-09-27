using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletCtrl : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 1500f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
