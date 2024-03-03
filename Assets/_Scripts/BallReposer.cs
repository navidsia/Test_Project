using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReposer : MonoBehaviour
{
    [SerializeField] private Vector2 force=new Vector2(0,10);

    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = force;
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rigidbody2D.velocity = force;
    }
}
