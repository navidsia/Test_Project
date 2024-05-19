using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool canPatrol;
    [SerializeField] int Health;
    [SerializeField] List<PatrolMovement> patrolPositions;
    [SerializeField] LayerMask characterLayer;
    [SerializeField] float characterDetectionRange;
    [SerializeField] int damage;
    List<Vector3> patrolPositionCopy;
    int patrolPosIndex=0;
    int _maxHealth;

    float time;
    private void Start()
    {
        _maxHealth = Health;
        patrolPositionCopy = new List<Vector3>();
        foreach (PatrolMovement t in patrolPositions)
        {
            patrolPositionCopy.Add(new Vector3(t.patrolPosition.position.x,t.patrolPosition.position.y,
                t.patrolPosition.position.z));
        }
    }

    public void GetHit(int damage)
    {
        if (Health <= 0)
        {
            return;
        }
        Health -= damage;
        if (Health <= 0)
            Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(canPatrol)
        {
            MoveToPosition(patrolPositionCopy[patrolPosIndex], patrolPositions[patrolPosIndex].duration);
        }
        var hit = Physics2D.OverlapCircle(transform.position, characterDetectionRange, characterLayer);
        if (hit)
        {
            hit.gameObject.GetComponent<CharacterController>().GetHit(damage);
        }

    }
    void MoveToPosition(Vector3 pos,float duration)
    {
        var t = duration;
        var prevIndex = patrolPosIndex - 1;
        if (patrolPosIndex < 1)
        {
            prevIndex = patrolPositionCopy.Count-1;
        }
        var newPos = Vector3.Lerp(patrolPositionCopy[prevIndex], pos, time/t);
        transform.position = newPos;
        CheckPatrolPositionReached();
    }
    void CheckPatrolPositionReached()
    {
        if (Vector3.Distance(patrolPositionCopy[patrolPosIndex],transform.position)<=0.1f)
        {
            patrolPosIndex++;
            if(patrolPosIndex >= patrolPositionCopy.Count)
            {
                patrolPosIndex = 0;
            }
            time = 0;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, characterDetectionRange);
    }
}
[System.Serializable]
class PatrolMovement
{
    public Transform patrolPosition;
    public float duration;
}
