using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.Instance.GetCurrentState() == GameMaster.GameState.GameOver)
            return;
    }

	private void FixedUpdate()
	{
        if (GetComponent<EnemyMeleeAttacker>().isTargetExist())
        {
            EnemyMove();
        }
    }

	void EnemyMove()
	{
        if (!GetComponent<EnemyMeleeAttacker>().IsAttacking)
        {
            Vector3 dir = GetComponent<EnemyMeleeAttacker>().GetTarget().position - transform.position;
            rb.MovePosition(transform.position + (dir.normalized * enemySO.enemyMoveSpeed * Time.fixedDeltaTime));
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,2f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1.7f);
    }

}
