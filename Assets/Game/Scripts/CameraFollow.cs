using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;
    public float yOffset = 1f;
    void Update()
    {
        Vector3 newpos = new Vector3(target.position.x + 8f, target.position.y + 3.5f,-10f);
        transform.position = Vector3.Slerp(transform.position, newpos, followSpeed*Time.deltaTime);
    }
}
