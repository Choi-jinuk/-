using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSBulletCtrl : MonoBehaviour
{
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        //Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(0, 0, 1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
