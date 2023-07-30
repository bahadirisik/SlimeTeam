using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
	protected List<Transform> creatureToAttackList;

    protected Transform target;

    protected virtual void FindClosestTarget()
	{
        float minDistance = Mathf.Infinity;
        foreach (Transform creatureToAttack in creatureToAttackList)
        {
            if (GetDistance(creatureToAttack) < minDistance)
            {
                target = creatureToAttack;
                minDistance = Vector3.Distance(creatureToAttack.position, transform.position);
            }
        }

    }

    protected abstract IEnumerator AttackTheClosestTarget();

    protected virtual float GetDistance(Transform target)
    {
        if (target != null)
        {
            return Vector3.Distance(transform.position, target.position);
        }

        return Mathf.Infinity;
    }

}
