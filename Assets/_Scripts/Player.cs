using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float jumpForce;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rigidbody2D.velocity=new Vector2(0, jumpForce);
        }
    }
    void GameOver()
    {
        GameManager.Instance.GameOver();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameOver();
        }
        else if (collision.gameObject.CompareTag("Pipe"))
        {
            GameOver();
        }
        else if (collision.gameObject.CompareTag("Score"))
        {
            GameManager.Instance.AddScore(1);   
        }
    }

    public void StartPlaying()
    {
        rigidbody2D.gravityScale = 1;
    }
}
