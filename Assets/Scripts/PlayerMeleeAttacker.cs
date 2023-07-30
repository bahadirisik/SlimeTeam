using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMeleeAttacker : Attacker
{
    [SerializeField] private UnityEvent OnPlayerAttack;
    [SerializeField] private UnityEvent OnPlayerAttackEnd;

    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private Animator anim;

	void Start()
    {
        creatureToAttackList = EnemySpawnManager.Instance.GetEnemyList();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.Instance.GetCurrentState() == GameMaster.GameState.GameOver)
            return;

        FindClosestTarget();

        if (GetDistance(target) < playerSO.minDistanceToAttack && !GetComponent<Player>().IsAttacking)
        {
            StartCoroutine(AttackTheClosestTarget());
        }

    }

    protected override IEnumerator AttackTheClosestTarget()
    {
        GetComponent<Player>().IsAttacking = true;

        if (GetDistance(target) < playerSO.minDistanceToDamage)
        {
            OnPlayerAttack.Invoke();
            anim.SetTrigger("Attack");
            target.GetComponent<EnemyHealth>().DecreaseHealth(playerSO.playerDamage);
        }

        yield return new WaitForSeconds(playerSO.playerFireRate);

        OnPlayerAttackEnd.Invoke();
        GetComponent<Player>().IsAttacking = false;
        StopCoroutine(AttackTheClosestTarget());
    }
}
