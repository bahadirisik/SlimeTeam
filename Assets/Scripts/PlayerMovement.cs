using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 firstPosition;
    private Vector3 targetPosition;

    private float timeToMove;
    private float startTimeToMove = 3f;
    private float moveSpeed = 1.5f;

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
        if (GameMaster.Instance.GetCurrentState() == GameMaster.GameState.GameOver)
            return;

        if (timeToMove < 0f)
		{
            timeToMove = startTimeToMove;
            targetPosition = GetRandomPosition();
		}

        if(!isArrived)
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
        Vector3 dir = targetPosition - transform.position;

        rb.MovePosition(transform.position + (dir.normalized * moveSpeed * Time.deltaTime));

        if (Vector3.Distance(transform.position,targetPosition) < 0.5f)
		{
            isArrived = true;
		}

	}

    private Vector3 GetRandomPosition()
	{
        isArrived = false;

        float randomX = Random.Range(-2f, 2f);
        float randomY = Random.Range(-4f, 4f);

        Vector3 newRandomPosition = firstPosition + new Vector3(randomX, randomY, 0f);
        Debug.Log(newRandomPosition);
        return newRandomPosition;
    }

}
