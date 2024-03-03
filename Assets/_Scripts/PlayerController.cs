using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minY, maxY;
    void Start()
    {
        
    }

    void Update()
    {

        float direction = Input.GetAxis("Vertical");
        float horizontal=Input.GetAxis("Horizontal");
        Debug.Log(direction);

        Vector2 temp = transform.position;
        temp.y+=1* direction*speed*Time.deltaTime;
        temp.y = Mathf.Clamp(temp.y, minY, maxY);
        transform.position = temp;

    }
}
