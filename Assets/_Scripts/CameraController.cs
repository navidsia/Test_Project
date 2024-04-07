using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform character;
    [SerializeField] Vector3 offset;
    [SerializeField] float yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = character.transform.position + offset;
        pos.y= yPos;
        transform.position = pos;
    }
}
