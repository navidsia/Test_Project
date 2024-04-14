using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField] GameObject shape;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float groundDetectionRange;
    [SerializeField] LayerMask groundMask;
    [SerializeField] int maxJumpCount;
    [SerializeField] KeyCode jumpKey;
    [SerializeField] float deathHeight;

    Rigidbody2D rigidbody2D;
    int _jumpCount;
    bool isOnGround;
    bool isRight=true;
    void Start()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckHeightDeath();
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        GroundDetection();
        MoveLogic(horizontalInput);
        FlipCheck(horizontalInput);
        if(Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    private void CheckHeightDeath()
    {
        if (transform.position.y < deathHeight)
            Die();
    }
    private void Die()
    {
        SceneManager.LoadScene(0);
    }

    private void FlipCheck(float input)
    {
        if (input < 0 && isRight)
            Flip();
        else if (input > 0 && !isRight)
            Flip();
    }

    private void Flip()
    {
        var scale = shape.transform.localScale;
        scale.x *= -1;
        shape.transform.localScale = scale;
        isRight = !isRight;
    }

    private void GroundDetection()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionRange,groundMask);
        if(!isOnGround && hit)
        {
            _jumpCount = 0;
        }
        isOnGround = hit;
    }

    private void MoveLogic(float input)
    {
        var v=rigidbody2D.velocity;
        v.x = input*movementSpeed;
        rigidbody2D.velocity = v;
    }


    private void Jump()
    {
        if (_jumpCount>=maxJumpCount)
            return;
        var v = rigidbody2D.velocity;
        v.y = jumpForce;
        rigidbody2D.velocity = v;
        _jumpCount++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.down*groundDetectionRange);
    }
}
