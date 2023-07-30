using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    //private const string PLAYER_MAX_SPAWN_AMOUNT = "MaxSpawnAmount";

    [SerializeField] private GameObject defaultPlayer;
    [SerializeField] private GameObject defaultCastle;

    private float startSpawnTimer = 4f;
    private float spawnTimer;
    private int maxSpawnAmount = 3;
    private int playerAmount;

    private List<Transform> playerTransforms;
    private Transform castle;


    private void Awake()
	{
        Instance = this;
	}

	void Start()
    {
        /*if (PlayerPrefs.GetInt(PLAYER_MAX_SPAWN_AMOUNT) > maxSpawnAmount)
        {
            maxSpawnAmount = PlayerPrefs.GetInt(PLAYER_MAX_SPAWN_AMOUNT);
        }*/

        SpawnCastle();

        spawnTimer = startSpawnTimer;
        playerAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMaster.Instance.GetCurrentState() == GameMaster.GameState.CountDown 
            || GameMaster.Instance.GetCurrentState() == GameMaster.GameState.GameOver)
		{
            return;
		}

        if(castle == null)
		{
            GameMaster.Instance.LevelFailed();
		}

        if(spawnTimer < 0f)
		{
            spawnTimer = startSpawnTimer;
            SpawnPlayer();
		}

        if(playerAmount < maxSpawnAmount)
		{
            spawnTimer -= Time.deltaTime;
		}
    }

    void SpawnCastle()
	{
        playerTransforms = new List<Transform>();

        castle = Instantiate(defaultCastle,Vector3.zero,Quaternion.identity).transform;
        playerTransforms.Add(castle);
    }

    void SpawnPlayer()
	{
        if (playerAmount >= maxSpawnAmount)
            return;

        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        Vector3 randomPosition = new Vector3(Mathf.Sign(randomX) * (Mathf.Clamp(Mathf.Abs(randomX), 2.5f, 3f)), Mathf.Sign(randomY) * (Mathf.Clamp(Mathf.Abs(randomY), 2.5f, 3f)), 0f);
        Transform playerTransform = Instantiate(defaultPlayer,randomPosition,Quaternion.identity).gameObject.transform;
        AddPlayerToTheList(playerTransform);
	}

    public List<Transform> GetPlayers()
	{
        return playerTransforms;
	}

    public void RemovePlayerFromList(Transform playerToRemove)
    {
        playerTransforms.Remove(playerToRemove);
        playerAmount--;

        Destroy(playerToRemove.gameObject);
    }

    public void AddPlayerToTheList(Transform playerToAdd)
	{
        playerTransforms.Add(playerToAdd);
        playerAmount++;
    }

    public void IncreaseMaxSpawnAmount(int amount,int cost)
	{
        if (GameMaster.Instance.GetCurrentCoin() < cost || maxSpawnAmount >= MainUpgrades.maxSoldierAmountUpgrade)
            return;

        GameMaster.Instance.ChangeCoin(-cost);
        maxSpawnAmount += amount;
        //PlayerPrefs.SetInt(PLAYER_MAX_SPAWN_AMOUNT,maxSpawnAmount);
	}

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,2.5f);
	}

}
