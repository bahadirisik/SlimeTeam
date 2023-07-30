using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { get; private set; }

    public event EventHandler<OnCoinIncreaseEventArgs> OnCoinChange;
    public event EventHandler<OnCountDownChangeEventArgs> OnCountDownChange;
    public event EventHandler OnLevelCompleted;
    public event EventHandler OnLevelFailed;
    public class OnCoinIncreaseEventArgs : EventArgs
	{
        public int coin;
	}

    public class OnCountDownChangeEventArgs : EventArgs
    {
        public float countdown;
    }

    //private const string PLAYER_COIN_AMOUNT = "PlayerCoinAmount";

    [SerializeField] private int levelCompletedMoney;

    public enum GameState
	{
        CountDown,
        Playing,
        GameOver,
	}

	private GameState gameState;

    private bool isGameOver = false;
    private int currentCoin;
    private float countDownTimer;
    private float startCountDownTimer = 3f;

	private void Awake()
	{
        Instance = this;
	}

	void Start()
    {
        //currentCoin = PlayerPrefs.GetInt(PLAYER_COIN_AMOUNT);
        currentCoin = 0;
        countDownTimer = startCountDownTimer;
        gameState = GameState.CountDown;


        /*OnCoinChange?.Invoke(this, new OnCoinIncreaseEventArgs
        {
            coin = currentCoin
        });*/
    }

    // Update is called once per frame
    void Update()
    {

        if(countDownTimer < 0f && gameState == GameState.CountDown)
		{
            gameState = GameState.Playing;
		}

        if(EnemySpawnManager.Instance.GetRemainingEnemy() <= 0 && !isGameOver)
		{
            LevelCompleted();
		}

        DecreaseCountDown();
        
    }

    private void LevelCompleted()
	{
        MainUpgrades.mainMoney += levelCompletedMoney;

        OnLevelCompleted?.Invoke(this,EventArgs.Empty);

        AudioManager.Instance.Play("LevelCompleted");
        gameState = GameState.GameOver;
        isGameOver = true;
	}

    public void LevelFailed()
	{
        if (isGameOver)
            return;

        AudioManager.Instance.Play("LevelFailed");
        gameState = GameState.GameOver;
        isGameOver = true;

        OnLevelFailed?.Invoke(this,EventArgs.Empty);
    }

    public void ChangeCoin(int amount)
	{
        currentCoin += amount;
        //PlayerPrefs.SetInt(PLAYER_COIN_AMOUNT,currentCoin);

        OnCoinChange?.Invoke(this, new OnCoinIncreaseEventArgs
        {
            coin = currentCoin
        });
	}

    public int GetCurrentCoin()
	{
        return currentCoin;
	}

    public GameState GetCurrentState()
	{
        return gameState;
	}

    void DecreaseCountDown()
	{
        countDownTimer -= Time.deltaTime;

        OnCountDownChange?.Invoke(this, new OnCountDownChangeEventArgs
        {
            countdown = countDownTimer
        });
	}
}
