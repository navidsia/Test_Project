using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpVelocity,moveSpeed;
    bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move(new Vector2(1, 0));
        }
        if (isJumping && rb.velocity==Vector2.zero)
        {
            isJumping = false;
        }
    }
    public void Jump()
    {
        if (isJumping) return;
        isJumping = true;
        rb.velocity = new Vector2(0, jumpVelocity);
    }
    public void Move(Vector2 direction)
    {
        transform.Translate(direction*Time.deltaTime*moveSpeed);
    }
}
