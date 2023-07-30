using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttacker : Attacker
{
    [SerializeField] private EnemySO enemySO;

    public bool IsAttacking { get; private set; } = false;

    void Start()
    {
        IsAttacking = false;
        creatureToAttackList = SpawnManager.Instance.GetPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.Instance.GetCurrentState() == GameMaster.GameState.GameOver)
            return;

        FindClosestTarget();

        if (GetDistance(target) < enemySO.minDistanceToAttack && !IsAttacking)
        {
            StartCoroutine(AttackTheClosestTarget());
        }

    }

	protected override void FindClosestTarget()
	{
        float minDistance = Mathf.Infinity;
        float minPriority = Mathf.Infinity;
        foreach (Transform creatureToAttack in creatureToAttackList)
        {
            PlayerSO playerSO = creatureToAttack.GetComponent<PlayerHealth>().GetPlayerSO();

            if (playerSO.priority > minPriority)
                continue;

            if (playerSO.priority < minPriority)
            {
                minPriority = playerSO.priority;
                minDistance = Mathf.Infinity;
            }

            if (GetDistance(creatureToAttack) < minDistance)
            {
                target = creatureToAttack;
                minDistance = Vector3.Distance(creatureToAttack.position, transform.position);
            }
        }
    }

	protected override IEnumerator AttackTheClosestTarget()
    {
        IsAttacking = true;
        if (GetDistance(target) < enemySO.minDistanceToDamage)
        {
            target.GetComponent<PlayerHealth>().DecreaseHealth(enemySO.enemyDamage);
        }

        yield return new WaitForSeconds(enemySO.enemyFireRate);

        IsAttacking = false;
        StopCoroutine(AttackTheClosestTarget());
    }

    public bool isTargetExist()
	{
        return target != null;
	}

    public Transform GetTarget()
    {
        return target;
    }
}
