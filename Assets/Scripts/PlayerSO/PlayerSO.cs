using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerSO : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject playerDeathEffect;
    public int playerHealth;
    public int playerDamage;
    public int priority;
    public float playerFireRate;
    public float minDistanceToAttack;
    public float minDistanceToDamage;
    public float playerMoveSpeed;
    public string playerName;
    public Sprite sprite;

}
