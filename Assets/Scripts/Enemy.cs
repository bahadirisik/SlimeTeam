using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;
    //private Transform target;

    private Rigidbody2D rb;
    //private int enemyCurrentHealth;
    //private bool isAttacking = false;

    void Start()
    {
        //enemyCurrentHealth = enemySO.enemyHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.Instance.GetCurrentState() == GameMaster.GameState.GameOver)
            return;

        /*if (enemyCurrentHealth <= 0)
		{
            EnemyDeath();
		}*/

        //FindClosestTarget();


        /*if(GetDistance(target) < enemySO.minDistanceToAttack && !isAttacking)
		{
            StartCoroutine(AttackTheClosestTarget());
		}*/

        /*if (GetComponent<EnemyMeleeAttacker>().isTargetExist())
        {
            EnemyMove();
        }*/
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

    /*void FindClosestTarget()
	{
        float minDistance = Mathf.Infinity;
		foreach (Transform player in SpawnManager.Instance.GetPlayers())
		{
			if (GetDistance(player) < minDistance)
			{
                target = player;
                minDistance = Vector3.Distance(player.position, transform.position);
            }
		}
	}*/

	/*IEnumerator AttackTheClosestTarget()
	{
        isAttacking = true;
		if (GetDistance(target) < enemySO.minDistanceToDamage)
		{
            target.GetComponent<Player>().DecreaseHealth(enemySO.enemyDamage);
		}

        yield return new WaitForSeconds(enemySO.enemyFireRate);

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

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,2f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1.7f);
    }

    /*public void DecreaseHealth(int damage)
	{
        enemyCurrentHealth -= damage;
	}*/

    /*void EnemyDeath()
    {
        GameMaster.Instance.ChangeCoin(enemySO.enemyMoney);
        EnemySpawnManager.Instance.RemoveEnemyFromList(transform);

        Destroy(gameObject);
    }*/

}
