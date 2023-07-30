using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemySO : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject enemyDeathEffect;
    public int enemyHealth;
    public int enemyDamage;
    public float enemyMoveSpeed;
    public float enemyFireRate;
    public float minDistanceToAttack;
    public float minDistanceToDamage;
    public int enemyMoney;
    public string enemyName;
    public Sprite sprite;

}
