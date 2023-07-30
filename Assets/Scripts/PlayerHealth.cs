using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{

    [SerializeField] private PlayerSO playerSO;

    private int currentHealt;

    void Start()
    {
        currentHealt = playerSO.playerHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealt <= 0)
		{
            Death();
		}
    }

	private void Death()
	{
        ParticleSystemManager.Instance.ActiveParticle(transform, playerSO.playerDeathEffect);

        SpawnManager.Instance.RemovePlayerFromList(transform);

        Destroy(gameObject);
	}

	public void DecreaseHealth(int damage)
	{
        currentHealt -= damage;
	}

    public PlayerSO GetPlayerSO()
	{
        return playerSO;
	}
}
