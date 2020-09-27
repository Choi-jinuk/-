using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundary
{
    public float x;
    public float y;
}
public class CameraCtrl : MonoBehaviour
{

    Transform tr;
    Vector3 targetPos = new Vector3(0,0,0);

    public Transform target;
    public Boundary cameraBoundary; 
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = target.position + (Vector3.up * 30f);
        targetPos.x = Mathf.Clamp(targetPos.x, (cameraBoundary.x * -1), cameraBoundary.x);
        targetPos.z = Mathf.Clamp(targetPos.z, (cameraBoundary.y * -1), cameraBoundary.y);
        tr.transform.position = targetPos;
    }
}
