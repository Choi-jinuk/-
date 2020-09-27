using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBulletMove : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0f, 0f, 5f) * Time.deltaTime);
    }
}
