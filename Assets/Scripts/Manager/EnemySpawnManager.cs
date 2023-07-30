using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public static EnemySpawnManager Instance { get; private set; }

    [SerializeField] private GameObject[] enemies;

    [SerializeField] private float minSpawnTimer;
    [SerializeField] private float maxSpawnTimer;

    private float startSpawnTimer = 3f;
    private float spawnTimer;
    [SerializeField] private int startMaxSpawnAmount = 20;
    private int maxSpawnAmount;
    private int remainingEnemy;

    private List<Transform> spawnedEnemyList;

	private void Awake()
	{
        Instance = this;
	}

	void Start()
    {
        remainingEnemy = startMaxSpawnAmount;
        spawnedEnemyList = new List<Transform>();
        maxSpawnAmount = startMaxSpawnAmount;
        spawnTimer = startSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.Instance.GetCurrentState() == GameMaster.GameState.GameOver)
        {
            return;
        }

        if (spawnTimer < 0f && maxSpawnAmount > 0)
		{
            spawnTimer = startSpawnTimer;
            SpawnEnemy();
		}

        spawnTimer -= Time.deltaTime;
    }


    void SpawnEnemy()
	{
        startSpawnTimer = Random.Range(minSpawnTimer,maxSpawnTimer);
        int randomAmount = Random.Range(0,3);

		for (int i = 0; i < randomAmount; i++)
		{
            if(maxSpawnAmount <= 0)
			{
                return;
			}

            float randomX = Random.Range(-13f, 13f);
            float randomY = Random.Range(-23f, 23f);

            Vector3 randomPosition = new Vector3(Mathf.Sign(randomX) * (Mathf.Clamp(Mathf.Abs(randomX), 11f, 14f)), Mathf.Sign(randomY) * (Mathf.Clamp(Mathf.Abs(randomY), 21f, 23f)), 0f);
            Transform spawnedEnemy = Instantiate(enemies[Random.Range(0,enemies.Length)], randomPosition, Quaternion.identity).transform;

            spawnedEnemyList.Add(spawnedEnemy);
            maxSpawnAmount--;
		}
	}

    public void RemoveEnemyFromList(Transform enemyToRemove)
	{
        remainingEnemy--;
        spawnedEnemyList.Remove(enemyToRemove);
	}

    public List<Transform> GetEnemyList()
	{
        return spawnedEnemyList;
	}

    public int GetRemainingEnemy()
	{
        return remainingEnemy;
	}
}
