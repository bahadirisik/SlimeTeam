using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private PlayerSO playerSO;
	[SerializeField] private GameObject deathEffect;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out IDamageable damageable))
		{
			damageable.DecreaseHealth(playerSO.playerDamage);

			GameObject projectileDeathEffect = Instantiate(deathEffect,transform.position,Quaternion.identity);
			Destroy(projectileDeathEffect,2f);

			Destroy(gameObject);
		}
	}

}
