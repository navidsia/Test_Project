using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector2 offset;
    [SerializeField] Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=target.position;
        pos.x+=offset.x;
        pos.y=offset.y;
        pos.z = -10;
        transform.position = pos;
    }
}
