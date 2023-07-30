using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;

    public bool IsAttacking { get; set; } = false;

    private Vector3 firstPosition;
    private Vector3 targetPosition;

    //private Transform target;

    private float timeToMove;
    private float startTimeToMove = 3f;
    //private int currentHealt;

    private Rigidbody2D rb;

    private bool isArrived = false;
    //private bool isAttacking = false;

    void Start()
    {
        //currentHealt = playerSO.playerHealth;
        rb = GetComponent<Rigidbody2D>();
        firstPosition = transform.position;
        timeToMove = startTimeToMove;
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (currentHealt <= 0)
        {
            Death();
        }*/

        //FindClosestTarget();


        /*if (GetDistance(target) < playerSO.minDistanceToAttack && !isAttacking)
        {
            StartCoroutine(AttackTheClosestTarget());
        }*/

        if (timeToMove < 0f)
        {
            timeToMove = startTimeToMove;
            targetPosition = GetRandomPosition();
        }

        if (!isArrived)
        {
            MoveToNewPosition();
        }

        if (isArrived)
        {
            timeToMove -= Time.deltaTime;
        }
    }

    private void MoveToNewPosition()
    {
        if (!IsAttacking)
        {
            Vector3 dir = targetPosition - transform.position;

            rb.MovePosition(transform.position + (dir.normalized * playerSO.playerMoveSpeed * Time.deltaTime));

            if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
            {
                isArrived = true;
            }
        }

    }

    private Vector3 GetRandomPosition()
    {
        isArrived = false;

        float randomX = Random.Range(-4f, 4f);
        float randomY = Random.Range(-7f, 7f);

        Vector3 newRandomPosition = firstPosition + new Vector3(randomX, randomY, 0f);
        return newRandomPosition;
    }

    /*void FindClosestTarget()
    {
        float minDistance = Mathf.Infinity;
        foreach (Transform enemy in EnemySpawnManager.Instance.GetEnemyList())
        {
            if (GetDistance(enemy) < minDistance)
            {
                target = enemy;
                minDistance = Vector3.Distance(enemy.position, transform.position);
            }
        }
    }*/

    /*IEnumerator AttackTheClosestTarget()
    {
        isAttacking = true;
        if (GetDistance(target) < playerSO.minDistanceToDamage)
        {
            target.GetComponent<Enemy>().DecreaseHealth(playerSO.playerDamage);
        }

        yield return new WaitForSeconds(playerSO.playerFireRate);

        isAttacking = false;
        StopCoroutine(AttackTheClosestTarget());
    }*/

    /*private float GetDistance(Transform target)
    {
        if (target != null)
        {
            return Vector3.Distance(transform.position, target.position);
        }

        return Mathf.Infinity;
    }*/

    /*private void Death()
    {
        SpawnManager.Instance.RemovePlayerFromList(transform);

        Destroy(gameObject);
    }*/

    /*public void DecreaseHealth(int damage)
    {
        currentHealt -= damage;
    }*/

    public PlayerSO GetPlayerSO()
	{
        return playerSO;
	}

	/*public void DecreaseHealth(int damage)
	{
        currentHealt -= damage;
	}*/
}
