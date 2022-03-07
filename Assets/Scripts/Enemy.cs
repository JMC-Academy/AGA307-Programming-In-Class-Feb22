using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType myType;
    public int myHealth;
    int baseHealth = 100;
    public float mySpeed;
    float baseSpeed = 2;

    [Header("AI")]
    public PatrolType myPatrol;
    int patrolPoint = 0;            //Needed for linear patrol movement
    bool reverse = false;           //Needed for repeat patrol movement
    Transform startPos;             //Needed for repeat patrol movement
    Transform endPos;               //Needed for repeat patrol movement
    public Transform moveToPos;
    EnemyManager _EM;

    void Start()
    {
        SetupEnemy();
        SetupAI();
        StartCoroutine(Move());
    }

    void SetupAI()
    {
        _EM = FindObjectOfType<EnemyManager>();
        startPos = transform;
        endPos = _EM.GetRandomSpawnPoint();
        moveToPos = endPos;
    }

    void SetupEnemy()
    {
        switch(myType)
        {
            case EnemyType.OneHand:
                myHealth = baseHealth;
                mySpeed = baseSpeed;
                myPatrol = PatrolType.Linear;
                break;
            case EnemyType.TwoHand:
                myHealth = baseHealth * 2;
                mySpeed = baseSpeed / 2;
                myPatrol = PatrolType.Loop;
                break;
            case EnemyType.Archer:
                myHealth = baseHealth / 2;
                mySpeed = baseSpeed * 2;
                myPatrol = PatrolType.Random;
                break;
            default:
                myHealth = baseHealth;
                mySpeed = baseSpeed;
                myPatrol = PatrolType.Random;
                break;
        }
    }

    IEnumerator Move()
    {
        switch (myPatrol)
        {
            case PatrolType.Random:
                moveToPos = _EM.GetRandomSpawnPoint();
                break;
            case PatrolType.Linear:
                moveToPos = _EM.spawnPoints[patrolPoint];
                patrolPoint = patrolPoint != _EM.spawnPoints.Length ? patrolPoint + 1 : 0;
                break;
            case PatrolType.Loop:
                moveToPos = reverse ? startPos : endPos;
                reverse = !reverse;
                break;
        }

        while (Vector3.Distance(transform.position, moveToPos.position) > 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, Time.deltaTime * mySpeed);
            transform.rotation = Quaternion.LookRotation(moveToPos.position);
            yield return null;
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(Move());
    }
}
