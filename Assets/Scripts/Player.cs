using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;

    public bool IsAttacking { get; set; } = false;

    private Vector3 firstPosition;
    private Vector3 targetPosition;

    private float timeToMove;
    private float startTimeToMove = 3f;

    private Rigidbody2D rb;

    private bool isArrived = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstPosition = transform.position;
        timeToMove = startTimeToMove;
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
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

    public PlayerSO GetPlayerSO()
	{
        return playerSO;
	}
}
