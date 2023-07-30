using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemySO enemySO;

    private int currentHealt;

    void Start()
    {
        currentHealt = enemySO.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealt <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        AudioManager.Instance.Play("EnemyDeath");
        CameraShake.Instance.ShakeCamera(5f,0.3f);
        ParticleSystemManager.Instance.ActiveParticle(transform,enemySO.enemyDeathEffect);

        GameMaster.Instance.ChangeCoin(enemySO.enemyMoney);
        EnemySpawnManager.Instance.RemoveEnemyFromList(transform);

        Destroy(gameObject);
    }

    public void DecreaseHealth(int damage)
    {
        currentHealt -= damage;
    }
}
