using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeDuration;
    [SerializeField] LayerMask detectionLayer;
    [SerializeField] float detectionRadius;

    bool hasShot;
    float _duration;
    int _direction;
    int _damage;
   
    public void Shoot(int direction,int damage)
    {
        hasShot = true;
        _duration = lifeDuration;
        _direction= direction;
        _damage = damage;
    }

    private void Update()
    {
        if (!hasShot)
            return;

        Move();

        var hit = Physics2D.OverlapCircle(transform.position, detectionRadius, detectionLayer);
        if (hit)
        {
            if(hit.gameObject.TryGetComponent<Enemy>(out var enemy)) 
            {
                enemy.GetHit(_damage);
            }
            Die();
            return;
        }



        if (_duration > 0)
        {
            _duration -= Time.deltaTime;
            if (_duration <= 0)
            {
                Die();
            }
        }
    }

    private void Move()
    {
        var pos = transform.position;
        pos.x += speed * Time.deltaTime * _direction;
        transform.position = pos;
    }

    void Die()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
