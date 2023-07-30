using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRangerAttacker : Attacker
{
    [SerializeField] private UnityEvent OnPlayerAttack;
    [SerializeField] private UnityEvent OnPlayerAttackEnd;

    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePosition;
    private float projectileSpeed = 5f;

    void Start()
    {
        creatureToAttackList = EnemySpawnManager.Instance.GetEnemyList();
    }

    // Update is called once per frame
    void Update()
    {
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

            Vector3 dir = target.position - transform.position;
            Transform projectileTransform = Instantiate(projectile,firePosition.position,Quaternion.identity).transform;
            projectileTransform.GetComponent<Rigidbody2D>().AddForce(dir.normalized * projectileSpeed,ForceMode2D.Impulse);
            Destroy(projectileTransform.gameObject,3f);
        }

        yield return new WaitForSeconds(playerSO.playerFireRate);

        OnPlayerAttackEnd.Invoke();

        GetComponent<Player>().IsAttacking = false;
        StopCoroutine(AttackTheClosestTarget());
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,15f);
	}

}
