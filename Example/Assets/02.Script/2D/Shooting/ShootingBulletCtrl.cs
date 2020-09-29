using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBulletCtrl : MonoBehaviour
{

    public float direction;
    private void Start()
    {
        Destroy(gameObject, 2.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 6.0f * direction);
    }
}
